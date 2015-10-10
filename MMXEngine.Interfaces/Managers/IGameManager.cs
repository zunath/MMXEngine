﻿using Microsoft.Xna.Framework;
using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace MMXEngine.Interfaces.Managers
{
    public interface IGameManager
    {
        void Initialize(GraphicsDeviceManager graphics);
        void Update(GameTime gameTime);
        void Draw();
        void Exit();
    }
}
