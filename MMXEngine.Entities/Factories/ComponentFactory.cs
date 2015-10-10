using System;
using Artemis;
using MMXEngine.Interfaces.Factories;

namespace MMXEngine.ECS.Factories
{
    public class ComponentFactory : IComponentFactory
    {
        public T Create<T>() where T : ComponentPoolable
        {
            return (T) Activator.CreateInstance(typeof (T));
        }
    }
}
