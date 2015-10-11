﻿using Microsoft.Xna.Framework;
using MMXEngine.Interfaces.Managers;
using MMXEngine.Windows.Factories;

namespace MMXEngine.Windows
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private IGameManager _gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
        }
        
        protected override void Initialize()
        {
            IOCContainer.Register(this);
            _gameManager = GameFactory.GetGameManager();
            _gameManager.Initialize(_graphics);

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _gameManager.Draw();
            base.Draw(gameTime);
        }
    }
}
