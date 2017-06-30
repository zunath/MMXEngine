using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MMXEngine.Contracts.Managers
{
    public interface IGameManager
    {
        void Initialize(GraphicsDeviceManager graphics, Type screenType);
        void Update(GameTime gameTime);
        void Draw();
        void Exit();
        void LoadContent(ContentManager content);
        void UnloadContent(ContentManager content);
    }
}
