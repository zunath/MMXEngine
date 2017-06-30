using System.IO.Abstractions;
using Artemis;
using Autofac;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.ScriptMethods;
using MMXEngine.Contracts.Systems;
using MMXEngine.ECS.Entities;
using MMXEngine.ScriptEngine;
using MMXEngine.ScriptEngine.Methods;
using MMXEngine.Systems.Update;
using MMXEngine.Windows.Game.Managers;
using MMXEngine.Windows.Shared;
using MMXEngine.Windows.Shared.Factories;
using MMXEngine.Windows.Shared.Helpers;
using MMXEngine.Windows.Shared.Managers;

namespace MMXEngine.Windows.Game
{
    public static class GameIOCContainer
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        
        public static void Register(Microsoft.Xna.Framework.Game game)
        {
            var builder = new ContainerBuilder();
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(new SpriteBatch(game.GraphicsDevice)).AsSelf();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();
            
            // Third Party Registrations
            builder.RegisterType<Texture2D>();
            builder.RegisterType<EntityWorld>().SingleInstance();
            builder.RegisterType<FileSystem>().As<IFileSystem>();
            
            // Managers
            builder.RegisterType<GraphicsManager>().As<IGraphicsManager>().SingleInstance();
            builder.RegisterType<GameManager>().As<IGameManager>().SingleInstance();
            builder.RegisterType<ScreenManager>().As<IScreenManager>().SingleInstance();
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
            builder.RegisterType<InputManager>().As<IInputManager>().SingleInstance();
            builder.RegisterType<CameraManager>().As<ICameraManager>().SingleInstance();
            builder.RegisterType<ScriptManager>().As<IScriptManager>().SingleInstance();
            builder.RegisterType<ContentManagerWrapper>().As<IContentManager>().SingleInstance();

            // Factories
            builder.RegisterType<EntityFactory>().As<IEntityFactory>().SingleInstance();
            builder.RegisterType<ComponentFactory>().As<IComponentFactory>().SingleInstance();
            builder.RegisterType<ScreenFactory>().As<IScreenFactory>().SingleInstance();
            builder.RegisterType<PlayerStateFactory>().As<IPlayerStateFactory>().SingleInstance();
            
            // Loaders
            builder.RegisterType<LevelLoader>().As<ILevelLoader>();
            builder.RegisterType<GameSystemLoader>().As<ISystemLoader>();

            // Script Methods
            builder.RegisterType<AudioMethods>().As<IAudioMethods>();
            builder.RegisterType<EntityMethods>().As<IEntityMethods>();
            builder.RegisterType<LevelMethods>().As<ILevelMethods>();
            builder.RegisterType<LocalDataMethods>().As<ILocalDataMethods>();
            builder.RegisterType<MiscellaneousMethods>().As<IMiscellaneousMethods>();
            builder.RegisterType<PhysicsMethods>().As<IPhysicsMethods>();
            builder.RegisterType<PlayerMethods>().As<IPlayerMethods>();
            builder.RegisterType<SpriteMethods>().As<ISpriteMethods>();

            var loadAssemblyCall = new Projectile();         // At the moment the Entities assembly isn't loaded when this is called, so the next set of instructions don't pick up anything.
            var loadAssemblyCall2 = new PhysicsSystem(); // These statements are a workaround for the time being to ensure the assembly is loaded before we register components.

            IOCContainerHelper.RegisterGameEntities(builder);
            IOCContainerHelper.RegisterComponents(builder);
            IOCContainerHelper.RegisterPlayerStates(builder);
            IOCContainerHelper.RegisterSystems(builder);
            IOCContainerHelper.RegisterScreens(builder);

            _container = builder.Build();
        }
    }
}
