using Artemis;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Entities;
using MMXEngine.Contracts.Factories;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;
using MMXEngine.ECS.Data;

namespace MMXEngine.ECS.Entities
{
    public class EditorLevel: IGameEntity
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IContentManager _content;

        public EditorLevel(IComponentFactory componentFactory,
            IContentManager content)
        {
            _componentFactory = componentFactory;
            _content = content;
        }

        public void BuildEntity(Entity entity, params object[] args)
        {
            int width = (int)args[0];
            int height = (int) args[1];
            string name = (string) args[2];
            string texturePath = (string) args[3];
            TileData[,] tiles = (TileData[,]) args[4];

            Map map = _componentFactory.Create<Map>();
            map.Width = width;
            map.Height = height;
            map.Spritesheet = _content.Load<Texture2D>(".\\Graphics\\Tilesets\\" + texturePath);
            map.Tiles = tiles;
            entity.AddComponent(map);

            Nameable nameable = _componentFactory.Create<Nameable>();
            nameable.Name = name;
            entity.AddComponent(nameable);
        }
    }
}
