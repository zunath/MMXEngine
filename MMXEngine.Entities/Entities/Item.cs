using Artemis;
using Artemis.Interface;

namespace MMXEngine.ECS.Entities
{
    public class Item: IEntityTemplate
    {
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {

            return entity;
        }
    }
}
