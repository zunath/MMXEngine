using System;
using Artemis;
using Artemis.Attributes;
using Artemis.System;
using MMXEngine.Contracts.Systems;

namespace MMXEngine.Windows.Shared
{
    public abstract class SystemLoaderBase: ISystemLoader
    {
        protected readonly EntityWorld World;

        protected SystemLoaderBase(EntityWorld world)
        {
            World = world;
        }

        public abstract void Load();

        protected void RegisterSystem(EntitySystem system)
        {
            Type type = system.GetType();
            ArtemisEntitySystem attribute = (ArtemisEntitySystem)type.GetCustomAttributes(typeof(ArtemisEntitySystem), true)[0];
            World.SystemManager.SetSystem(system, attribute.GameLoopType, attribute.Layer, attribute.ExecutionType);
        }
    }
}
