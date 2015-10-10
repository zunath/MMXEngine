using System;
using System.Linq;
using Artemis;
using Artemis.Attributes;
using Artemis.System;
using Autofac;
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
            var systemTypes = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(EntitySystem).IsAssignableFrom(p) && !p.ToString().StartsWith("Artemis"));

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
