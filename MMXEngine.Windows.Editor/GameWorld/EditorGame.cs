using Microsoft.Practices.ServiceLocation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Screens;
using MMXEngine.Windows.Editor.Interop;

namespace MMXEngine.Windows.Editor.GameWorld
{
    public class EditorGame: WpfGame
    {
        private readonly WpfGraphicsDeviceService _graphics;
        private IGameManager _gameManager;

        public EditorGame(GraphicsDevice graphics) 
            : base(graphics)
        {
            _graphics = new WpfGraphicsDeviceService(this);

            Content.RootDirectory = "Content/Compiled";
        }

        protected override void Initialize()
        {
            _gameManager = ServiceLocator.Current.TryResolve<IGameManager>();
            _gameManager.Initialize<LevelEditorScreen>(null);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            _gameManager.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            _gameManager.Draw();
            base.Draw(gameTime);
        }
    }
}
