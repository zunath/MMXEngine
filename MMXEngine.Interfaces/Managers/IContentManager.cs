using System;
using Microsoft.Xna.Framework.Content;

namespace MMXEngine.Contracts.Managers
{
    public interface IContentManager
    {
        string RootDirectory { get; }
        IServiceProvider ServiceProvider { get; }
        T Load<T>(string assetName);
        void Unload();
        void LoadContent(ContentManager content);
    }
}
