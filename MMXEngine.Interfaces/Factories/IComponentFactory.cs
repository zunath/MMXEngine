using Artemis;

namespace MMXEngine.Interfaces.Factories
{
    public interface IComponentFactory
    {
        T Create<T>() where T : ComponentPoolable;
    }
}
