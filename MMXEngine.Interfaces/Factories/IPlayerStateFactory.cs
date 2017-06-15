using MMXEngine.Contracts.States;

namespace MMXEngine.Contracts.Factories
{
    public interface IPlayerStateFactory
    {
        T Create<T>()
            where T : IPlayerState;
    }
}
