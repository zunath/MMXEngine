using Artemis.Interface;

namespace MMXEngine.ECS.Components
{
    public class Map : IComponent
    {
        public string Name { get; set; }
        public string SpritesheetName { get; set; }
        public Tile[,] Tiles { get; set; }
    }
}
