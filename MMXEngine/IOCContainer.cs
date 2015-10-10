using Artemis;
using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Entities;
using MMXEngine.Interfaces.Entities;
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

            builder.RegisterType<EntityWorld>().SingleInstance();
            builder.RegisterType<CameraManager>().As<ICameraManager>().SingleInstance();
            builder.RegisterType<ContentManager>().As<IContentManager>().SingleInstance();
            builder.RegisterType<GameObjectManager>().As<IGameObjectManager>().SingleInstance();
            builder.RegisterType<GraphicsManager>().As<IGraphicsManager>().SingleInstance();
            builder.RegisterType<ScreenManager>().As<IScreenManager>().SingleInstance();
            builder.RegisterType<GameManager>().As<IGameManager>().SingleInstance();

            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<Enemy>().As<IEnemy>();



            _container = builder.Build();
        }
    }
}
