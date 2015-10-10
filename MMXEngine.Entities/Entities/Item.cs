using Artemis;
using MMXEngine.Interfaces.Entities;

namespace MMXEngine.ECS.Entities
{
    public class Item: IGameEntity
    {
        public Entity BuildEntity(Entity entity)
        {
            return entity;
        }
    }
}
