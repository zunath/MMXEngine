using System;
using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.Systems;

namespace MMXEngine.Windows.Editor.Managers
{
    public class EditorGameManager : IGameManager
    {
        private readonly EntityWorld _world;
        private readonly SpriteBatch _spriteBatch;
        private readonly IGraphicsManager _graphicsManager;
        private readonly ISystemLoader _systemLoader;
        private readonly IScreenManager _screenManager;
        private readonly IScreenFactory _screenFactory;
        private readonly IEditorInputManager _inputManager;
        private readonly ICameraManager _cameraManager;
        private readonly IScriptManager _scriptManager;
        private readonly IContentManager _contentManager;

        public EditorGameManager(
            EntityWorld world,
            SpriteBatch spriteBatch,
            IGraphicsManager graphicsManager,
            ISystemLoader systemLoader,
            IScreenManager screenManager,
            IScreenFactory screenFactory,
            IEditorInputManager inputManager,
            ICameraManager cameraManager,
            IScriptManager scriptManager,
            IContentManager contentManager
            )
        {
            _world = world;
            _spriteBatch = spriteBatch;
            _graphicsManager = graphicsManager;
            _systemLoader = systemLoader;
            _screenManager = screenManager;
            _screenFactory = screenFactory;
            _inputManager = inputManager;
            _cameraManager = cameraManager;
            _scriptManager = scriptManager;
            _contentManager = contentManager;
        }

        public void Initialize(GraphicsDeviceManager graphics, Type screenType)
        {
            if (!typeof(IScreen).IsAssignableFrom(screenType))
            {
                throw new Exception("screenType must implement the IScreen interface.");
            }
            _systemLoader.Load();

            IScreen initialScreen = _screenFactory.Create(screenType);
            _screenManager.ChangeScreen(initialScreen);
        }
        
        public void Update(GameTime gameTime)
        {
            _inputManager.Update();
            _world.Update();
            _screenManager.Update();
            _scriptManager.ExecuteScripts();
        }
        
        public void Draw()
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, 
                BlendState.AlphaBlend, 
                null, 
                null,
                null, 
                null, 
                _cameraManager.Transform);
            _screenManager.Draw();
            _world.Draw();

            _spriteBatch.End();
        }
        
        public void Exit()
        {
        }

        public void LoadContent(ContentManager content)
        {
            _contentManager.LoadContent(content);
        }

        public void UnloadContent(ContentManager content)
        {
            _contentManager.Unload();
        }
    }
}
