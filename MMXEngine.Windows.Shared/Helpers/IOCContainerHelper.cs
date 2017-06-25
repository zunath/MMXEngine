using System;
using System.Linq;
using Artemis.Interface;
using Artemis.System;
using Autofac;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.States;

namespace MMXEngine.Windows.Shared.Helpers
{
    public class IOCContainerHelper
    {
        public static void RegisterGameEntities(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var gameEntities = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IGameEntity).IsAssignableFrom(p) && p.IsClass).ToArray();
            foreach (Type type in gameEntities)
            {
                builder.RegisterType(type).As<IGameEntity>().Named<IGameEntity>(type.ToString());
            }
        }

        public static void RegisterComponents(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var components = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IComponent).IsAssignableFrom(p) && p.IsClass);
            foreach (Type type in components)
            {
                builder.RegisterType(type).As<IComponent>().Named<IComponent>(type.ToString());
            }

        }

        public static void RegisterPlayerStates(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var states = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IPlayerState).IsAssignableFrom(p) && p.IsClass);
            foreach (Type type in states)
            {
                builder.RegisterType(type).As<IPlayerState>().Named<IPlayerState>(type.ToString());
            }
        }

        public static void RegisterSystems(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var systems = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(EntitySystem).IsAssignableFrom(p) && !p.ToString().StartsWith("Artemis"));
            foreach (Type type in systems)
            {
                builder.RegisterType(type);
            }
        }

        public static void RegisterScreens(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var screens = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IScreen).IsAssignableFrom(p) && p.IsClass);
            foreach (Type type in screens)
            {
                builder.RegisterType(type).As<IScreen>().Named<IScreen>(type.ToString());
            }
        }
    }
}
