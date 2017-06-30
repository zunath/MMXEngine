using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;

namespace MMXEngine.Windows.Editor.Managers
{
    public class ContentManagerWrapper: IContentManager
    {
        private readonly GraphicsDevice _graphics;
        private ContentManager _content;

        public ContentManagerWrapper(GraphicsDevice graphics)
        {
            _graphics = graphics;
        }

        public string RootDirectory
        {
            get => _content.RootDirectory;
            set => _content.RootDirectory = value;
        }

        public IServiceProvider ServiceProvider => _content.ServiceProvider;

        public T Load<T>(string assetName)
        {
            return _content.Load<T>(assetName);
        }

        public void Unload()
        {
            _content?.Unload();
        }

        public void LoadContent(ContentManager content)
        {
            if (_content != null) return;

            _content = content;
        }

    }
}
