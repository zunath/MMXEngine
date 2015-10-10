using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace MMXEngine.Interfaces.Managers
{
    public interface IContentManager
    {
        void LoadContent(XnaContentManager xnaContent);
        void UnloadContent();
    }
}
