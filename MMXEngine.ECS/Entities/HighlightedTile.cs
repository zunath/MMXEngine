using Artemis;
using Microsoft.Xna.Framework;
using MMXEngine.Contracts.Entities;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.Entities
{
    public class HighlightedTile: IGameEntity
    {
        public void BuildEntity(Entity entity, params object[] args)
        {
            int x = (int)args[0];
            int y = (int)args[1];
            int width = (int)args[2];
            int height = (int)args[3];
            Color color = (Color) args[4];
            RenderableRectangle rectangle = new RenderableRectangle(x, y, width, height, color);
            entity.AddComponent(rectangle);
        }
    }
}
