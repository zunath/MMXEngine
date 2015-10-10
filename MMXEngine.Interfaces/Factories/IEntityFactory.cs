using Artemis;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.Interfaces.Factories
{
    public interface IEntityFactory
    {
        Entity Create<T>() where T: IGameEntity;
    }
}
