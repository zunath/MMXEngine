using Microsoft.Xna.Framework;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Screens;

namespace MMXEngine.Windows.Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private IGameManager _gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
        }
        
        protected override void Initialize()
        {
            GameIOCContainer.Register(this);
            _gameManager = GameIOCContainer.Resolve<IGameManager>();
            _gameManager.LoadContent(Content);
            _gameManager.Initialize<GameScreen>(_graphics);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _gameManager.Draw();
            base.Draw(gameTime);
        }
    }
}
