using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Autofac;
using MMXEngine.Common.Attributes;
using MMXEngine.Interfaces.Systems;

namespace MMXEngine.Windows.Managers
{
    public class SystemLoader : ISystemLoader
    {
        private readonly EntityWorld _world;
        private readonly IComponentContext _context;

        public SystemLoader(EntityWorld world, 
            IComponentContext context)
        {
            _world = world;
            _context = context;
        }

        public void Load()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var updateSystemTypes = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(EntitySystem).IsAssignableFrom(p) && 
                            !p.ToString().StartsWith("Artemis") && 
                            ((ArtemisEntitySystem)p.GetCustomAttribute(typeof(ArtemisEntitySystem))).GameLoopType == GameLoopType.Update)
                .OrderBy(o => ((LoadableSystemAttribute)o.GetCustomAttribute(typeof(LoadableSystemAttribute))).LoadOrder)
                .ToList();
            var drawSystemTypes = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(EntitySystem).IsAssignableFrom(p) &&
                            !p.ToString().StartsWith("Artemis") &&
                            ((ArtemisEntitySystem)p.GetCustomAttribute(typeof(ArtemisEntitySystem))).GameLoopType == GameLoopType.Draw)
                .OrderBy(o => ((LoadableSystemAttribute)o.GetCustomAttribute(typeof(LoadableSystemAttribute))).LoadOrder)
                .ToList();

            var systemTypes = new List<Type>();
            systemTypes.AddRange(updateSystemTypes);
            systemTypes.AddRange(drawSystemTypes);

            foreach (var type in systemTypes)
            {
                ArtemisEntitySystem attribute = type.GetCustomAttributes(typeof (ArtemisEntitySystem), true).FirstOrDefault() as ArtemisEntitySystem;

                if (attribute == null)
                {
                    throw new Exception("Unable to locate ArtemisEntitySystem attribute for type: " + type);
                }

                var system = _context.ResolveNamed<EntitySystem>(type.ToString());

                _world.SystemManager.SetSystem(system, attribute.GameLoopType, attribute.Layer, attribute.ExecutionType);

            }


        }
    }
}
