using System;
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
using MMXEngine.Windows.Editor.GameWorld;
using MMXEngine.Windows.Editor.Managers;
using MMXEngine.Windows.Shared;
using MMXEngine.Windows.Shared.Factories;
using MMXEngine.Windows.Shared.Helpers;
using MMXEngine.Windows.Shared.Managers;
using MonoGame.Extended;

namespace MMXEngine.Windows.Editor
{
    public class EditorIOCContainer
    {
        public static void Register(ContainerBuilder builder)
        {

            // Third Party Registrations
            builder.RegisterType<EntityWorld>().SingleInstance();
            builder.RegisterType<FileSystem>().As<IFileSystem>();

            // Managers
            builder.RegisterType<GraphicsManager>().As<IGraphicsManager>().SingleInstance();
            builder.RegisterType<EditorGameManager>().As<IGameManager>().SingleInstance();
            builder.RegisterType<ScreenManager>().As<IScreenManager>().SingleInstance();
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
            builder.RegisterType<EditorInputManager>().As<IInputManager>().SingleInstance();
            builder.RegisterType<CameraManager>().As<ICameraManager>().SingleInstance();
            builder.RegisterType<ScriptManager>().As<IScriptManager>().SingleInstance();


            // Factories
            builder.RegisterType<EntityFactory>().As<IEntityFactory>().SingleInstance();
            builder.RegisterType<ComponentFactory>().As<IComponentFactory>().SingleInstance();
            builder.RegisterType<ScreenFactory>().As<IScreenFactory>().SingleInstance();
            builder.RegisterType<PlayerStateFactory>().As<IPlayerStateFactory>().SingleInstance();

            // Loaders
            builder.RegisterType<LevelLoader>().As<ILevelLoader>();
            builder.RegisterType<EditorSystemLoader>().As<ISystemLoader>();

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


            RegisterMonogame(builder);
        }

        private static void RegisterMonogame(ContainerBuilder builder)
        {
            // Create Direct3D 11 device.
            var presentationParameters = new PresentationParameters
            {
                // Do not associate graphics device with window.
                DeviceWindowHandle = IntPtr.Zero,
            };
            var device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, presentationParameters);

            builder.RegisterInstance(device).AsSelf();
            builder.RegisterInstance(new SpriteBatch(device)).AsSelf();
            builder.RegisterInstance(new Camera2D(device)).AsSelf();

            var game = new EditorGame(device);
            builder.RegisterInstance(game);
            builder.RegisterType<Texture2D>();
            builder.RegisterInstance(game.Content).AsSelf();
        }
    }
}
