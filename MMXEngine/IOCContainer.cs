using System;
using System.Linq;
using Artemis;
using Artemis.Interface;
using Artemis.System;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Entities;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;
using MMXEngine.Interfaces.Systems;
using MMXEngine.ScriptEngine;
using MMXEngine.Systems.Draw;
using MMXEngine.Systems.Update;
using MMXEngine.Windows.Factories;
using MMXEngine.Windows.Managers;

namespace MMXEngine.Windows
{
    public static class IOCContainer
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        
        public static void Register(Game game)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var builder = new ContainerBuilder();
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(new SpriteBatch(game.GraphicsDevice)).AsSelf();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();
            
            builder.RegisterType<Texture2D>();
            builder.RegisterType<EntityWorld>().SingleInstance();
            
            builder.RegisterType<GraphicsManager>().As<IGraphicsManager>().SingleInstance();
            builder.RegisterType<GameManager>().As<IGameManager>().SingleInstance();
            builder.RegisterType<ScreenManager>().As<IScreenManager>().SingleInstance();
            builder.RegisterType<DataManager>().As<IDataManager>().SingleInstance();
            builder.RegisterType<InputManager>().As<IInputManager>().SingleInstance();
            builder.RegisterType<CameraManager>().As<ICameraManager>().SingleInstance();
            builder.RegisterType<ScriptManager>().As<IScriptManager>().SingleInstance();

            builder.RegisterType<EntityFactory>().As<IEntityFactory>().SingleInstance();
            builder.RegisterType<ComponentFactory>().As<IComponentFactory>().SingleInstance();
            builder.RegisterType<ScreenFactory>().As<IScreenFactory>().SingleInstance();
            builder.RegisterType<SystemLoader>().As<ISystemLoader>();

            var loadAssemblyCall = new Item();         // At the moment the Entities assembly isn't loaded when this is called, so the next set of instructions don't pick up anything.
            var loadAssemblyCall2 = new PhysicsSystem(); // These statements are a workaround for the time being to ensure the assembly is loaded before we register components.

            // Register IGameEntity implementations
            var gameEntities = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IGameEntity).IsAssignableFrom(p) && p.IsClass).ToArray();
            foreach (Type type in gameEntities)
            {
                builder.RegisterType(type).As<IGameEntity>().Named<IGameEntity>(type.ToString());
            }

            // Register IComponent implementations
            var components = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IComponent).IsAssignableFrom(p) && p.IsClass);
            foreach (Type type in components)
            {
                builder.RegisterType(type).As<IComponent>().Named<IComponent>(type.ToString());
            }

            // Register systems excluding Artemis implementations
            var systems = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof (EntitySystem).IsAssignableFrom(p) && !p.ToString().StartsWith("Artemis"));
            foreach (Type type in systems)
            {
                builder.RegisterType(type).As<EntitySystem>().Named<EntitySystem>(type.ToString());
            }
            
            // Register screens
            var screens = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof (IScreen).IsAssignableFrom(p) && p.IsClass);
            foreach (Type type in screens)
            {
                builder.RegisterType(type).As<IScreen>().Named<IScreen>(type.ToString());
            }

            _container = builder.Build();
        }
    }
}
