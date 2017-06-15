using MMXEngine.Contracts.Entities;

namespace MMXEngine.Contracts.Factories
{
    public interface IScreenFactory
    {
        IScreen Create<T>() where T : IScreen;
    }
}
