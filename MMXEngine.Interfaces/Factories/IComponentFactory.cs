using Artemis.Interface;

namespace MMXEngine.Contracts.Factories
{
    public interface IComponentFactory
    {
        T Create<T>() where T: IComponent;
    }
}
