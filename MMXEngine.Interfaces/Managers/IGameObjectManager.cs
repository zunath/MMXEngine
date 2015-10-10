using Microsoft.Xna.Framework;

namespace MMXEngine.Interfaces.Managers
{
    public interface IGameObjectManager
    {
        void LoadContent();
        void Update(GameTime gameTime);
        void Draw();
    }
}
