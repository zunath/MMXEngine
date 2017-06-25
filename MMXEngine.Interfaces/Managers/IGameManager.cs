using Microsoft.Xna.Framework;
using MMXEngine.Contracts.Entities;

namespace MMXEngine.Contracts.Managers
{
    public interface IGameManager
    {
        void Initialize<T>(GraphicsDeviceManager graphics)
            where T: IScreen;
        void Update(GameTime gameTime);
        void Draw();
        void Exit();
    }
}
