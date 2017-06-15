using Microsoft.Xna.Framework;

namespace MMXEngine.Contracts.Managers
{
    public interface IGameManager
    {
        void Initialize(GraphicsDeviceManager graphics);
        void Update(GameTime gameTime);
        void Draw();
        void Exit();
    }
}
