using MMXEngine.Interfaces.Managers;
using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace MMXEngine.Windows.Managers
{
    public class ContentManager: IContentManager
    {
        private XnaContentManager _content;
        
        public void LoadContent(XnaContentManager xnaContent)
        {
            if (null != _content) return;

            _content = xnaContent;
            _content.RootDirectory = "Content";
        }
        
        public void UnloadContent()
        {
            _content?.Unload();
        }
    }
}
