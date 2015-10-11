using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Windows.Managers
{
    public class LevelManager : ILevelManager
    {
        private readonly ContentManager _contentManager;
        private readonly IDataManager _dataManager;
        private Texture2D _texture;
        private Map _map;
        private readonly SpriteBatch _spriteBatch;
        private readonly ICameraManager _cameraManager;

        public LevelManager(IDataManager dataManager, ICameraManager cameraManager, ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _dataManager = dataManager;
            _spriteBatch = spriteBatch;
            _cameraManager = cameraManager;
        }
        
        public void ChangeLevel(string levelName)
        {
            _map = _dataManager.Load<Map>("./Levels/" + levelName + ".json");
            _texture = _contentManager.Load<Texture2D>("./Tilesets/" + _map.SpritesheetName);
        }

        public void Draw()
        {
            if (_map == null) return;

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _cameraManager.Transform);

            var tiles = _map.Tiles;
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    Tile tile = _map.Tiles[x, y];
                    if (tile == null) continue;

                    Vector2 position = new Vector2(tile.X * 32, tile.Y * 32);
                    Rectangle source = new Rectangle(tile.TextureX * 32, tile.TextureY * 32,  32, 32);

                    _spriteBatch.Draw(_texture, position, source, Color.White);
                }
            }

            _spriteBatch.End();
        }

    }
}
