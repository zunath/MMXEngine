using Artemis;
using MMXEngine.Contracts.Entities;

namespace MMXEngine.Contracts.Factories
{
    public interface IEntityFactory
    {
        Entity Create<T>(params object[] args) where T: IGameEntity;
    }
}
