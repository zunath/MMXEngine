using System;
using System.IO;
using System.IO.Abstractions;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Data;
using MMXEngine.Windows.Editor.Events.LevelEditor;
using MMXEngine.Windows.Editor.Helpers;
using Prism.Events;
using Prism.Mvvm;

namespace MMXEngine.Windows.Editor.Views.TileSelectorView
{
    public class TileSelectorViewModel: BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IContentManager _content;
        private readonly IFileSystem _fileSystem;

        public TileSelectorViewModel(IEventAggregator eventAggregator,
            IContentManager content,
            IFileSystem fileSystem)
        {
            _eventAggregator = eventAggregator;
            _content = content;
            _fileSystem = fileSystem;
            
            LoadNoTextureImage();

            _eventAggregator.GetEvent<LevelTextureChangedEvent>().Subscribe(OnLevelTextureChanged);
            _eventAggregator.GetEvent<LevelOpenedEvent>().Subscribe(OnLevelOpened);
            _eventAggregator.GetEvent<LevelClosedEvent>().Subscribe(OnLevelClosed);
        }


        private BitmapImage _texture;

        public BitmapImage Texture
        {
            get => _texture;
            set => SetProperty(ref _texture, value);
        }
        
        private void OnLevelTextureChanged(string textureFile)
        {
            LoadTexture(textureFile);
        }

        private void LoadNoTextureImage()
        {
            Uri uri = new Uri("/Content/Graphics/NoTilesetSelected.png", UriKind.Relative);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
            if(resourceInfo == null)
                throw new Exception("Could not load 'No Texture' image.");

            Texture = BitmapImageHelpers.LoadFromStream(resourceInfo.Stream);
        }

        private void LoadTexture(string textureFile)
        {
            string path = "Graphics\\Tilesets\\" + _fileSystem.Path.ChangeExtension(textureFile, null);
            Texture2D texture = _content.Load<Texture2D>(path);
            MemoryStream stream = new MemoryStream();
            texture.SaveAsPng(stream, texture.Width, texture.Height);

            Texture = BitmapImageHelpers.LoadFromStream(stream);
        }

        private void OnLevelOpened(LevelData levelData)
        {
            LoadTexture(levelData.Spritesheet);
        }

        private void OnLevelClosed()
        {
            LoadNoTextureImage();
        }


    }
}
