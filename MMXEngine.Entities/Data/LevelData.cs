namespace MMXEngine.ECS.Data
{
    public class LevelData
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Spritesheet { get; set; }
        public TileData[,] Tiles { get; set; }
        public string BGMFile { get; set; }

        public LevelData()
        {
            Tiles = new TileData[Width,Height];
        }

        public LevelData(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new TileData[Width,Height];
        }
    }
}
