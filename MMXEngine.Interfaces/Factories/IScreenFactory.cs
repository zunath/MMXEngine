using MMXEngine.Interfaces.Entities;

namespace MMXEngine.Interfaces.Factories
{
    public interface IScreenFactory
    {
        IScreen Create<T>() where T : IScreen;
    }
}
