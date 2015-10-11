using Artemis;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.Interfaces.Factories
{
    public interface IEntityFactory
    {
        Entity Create<T>(params object[] args) where T: IGameEntity;
    }
}
