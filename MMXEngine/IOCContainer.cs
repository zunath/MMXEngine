using System;
using System.Linq;
using Artemis;
using Artemis.System;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Entities;
using MMXEngine.ECS.Factories;
using MMXEngine.Interfaces.Factories;
using MMXEngine.Interfaces.Managers;
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
            var builder = new ContainerBuilder();
            game.Content.RootDirectory = "Content";

            builder.RegisterInstance(new SpriteBatch(game.GraphicsDevice)).AsSelf();
            builder.RegisterInstance(game.Content).AsSelf();
            builder.RegisterInstance(game.GraphicsDevice).AsSelf();

            builder.RegisterType<Texture2D>();
            builder.RegisterType<EntityWorld>().SingleInstance();
            builder.RegisterType<CameraManager>().As<ICameraManager>().SingleInstance();
            builder.RegisterType<GameObjectManager>().As<IGameObjectManager>().SingleInstance();
            builder.RegisterType<GraphicsManager>().As<IGraphicsManager>().SingleInstance();
            builder.RegisterType<ScreenManager>().As<IScreenManager>().SingleInstance();
            builder.RegisterType<GameManager>().As<IGameManager>().SingleInstance();

            builder.RegisterType<Player>();
            builder.RegisterType<ComponentFactory>().As<IComponentFactory>();

            builder.RegisterTypes((from a in AppDomain.CurrentDomain.GetAssemblies()
                                   from t in a.GetTypes()
                                   where t.IsDefined(typeof(EntityProcessingSystem), true)
                                   select t).ToArray());

            _container = builder.Build();
        }
    }
}
