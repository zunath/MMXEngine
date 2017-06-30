using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        void LoadContent(ContentManager content);
        void UnloadContent(ContentManager content);
    }
}
