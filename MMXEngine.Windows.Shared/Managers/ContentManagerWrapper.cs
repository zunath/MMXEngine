using System;
using Microsoft.Xna.Framework.Content;
using MMXEngine.Contracts.Managers;

namespace MMXEngine.Windows.Shared.Managers
{
    public class ContentManagerWrapper: IContentManager
    {
        private ContentManager _content;
        
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
