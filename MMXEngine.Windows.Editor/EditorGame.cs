using System;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Managers;
using MMXEngine.Windows.Editor.Contracts;
using MMXEngine.Windows.Editor.Interop;

namespace MMXEngine.Windows.Editor
{
    public class EditorGame: WpfGame
    {
        private readonly WpfGraphicsDeviceService _graphics;
        private IGameManager _gameManager;
        private Type _initialScreen;

        public EditorGame(GraphicsDevice graphics)
            : base(graphics)
        {
            _graphics = new WpfGraphicsDeviceService(this);
            Loaded += EditorGame_Loaded;
        }

        private void EditorGame_Loaded(object sender, RoutedEventArgs e)
        {
            if(_initialScreen == null)
                throw new Exception("Initial screen must be set at the time of game construction.");

            _gameManager = ServiceLocator.Current.TryResolve<IGameManager>();
            _gameManager.LoadContent(Content);
            _gameManager.Initialize(null, _initialScreen);

			ServiceLocator.Current.TryResolve<IEditorInputManager>().Register(this);
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

        public void SetInitialScreen<T>()
            where T: IScreen
        {
            if (_initialScreen != null)
            {
                throw new Exception("Initial screen has already been set.");
            }

            _initialScreen = typeof(T);
        }
    }
}
