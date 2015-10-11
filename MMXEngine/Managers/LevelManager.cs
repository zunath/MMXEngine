using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;
using TiledSharp;

namespace MMXEngine.Windows.Managers
{
    public class LevelManager : ILevelManager
    {
        private readonly ContentManager _contentManager;
        private readonly IDataManager _dataManager;
        private Texture2D _tileset;
        private TmxMap _map;
        private readonly SpriteBatch _spriteBatch;
        private readonly ICameraManager _cameraManager;
        private int _tileWidth;
        private int _tileHeight;
        private int _tilesetTilesWide;
        private int _tilesetTilesHigh;

        public LevelManager(IDataManager dataManager, ICameraManager cameraManager, ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _dataManager = dataManager;
            _spriteBatch = spriteBatch;
            _cameraManager = cameraManager;
        }
        
        public void ChangeLevel(string levelName)
        {
            _map = new TmxMap("./Data/Levels/" + levelName + ".tmx");
            _tileset = _contentManager.Load<Texture2D>("Tilesets/" + _map.Tilesets[0].Name + ".png");

            _tileWidth = _map.Tilesets[0].TileWidth;
            _tileHeight = _map.Tilesets[0].TileHeight;

            _tilesetTilesWide = _tileset.Width / _tileWidth;
            _tilesetTilesHigh = _tileset.Height / _tileHeight;
        }

        public void Draw()
        {
            if (_map == null) return;

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _cameraManager.Transform);


            for (var i = 0; i < _map.Layers[0].Tiles.Count; i++)
            {
                int gid = _map.Layers[0].Tiles[i].Gid;
                if (gid == 0) continue;

                int tileFrame = gid - 1;
                int column = tileFrame % _tilesetTilesWide;
                int row = (tileFrame + 1 > _tilesetTilesWide) ? tileFrame - column * _tilesetTilesWide : 0;

                float x = (i % _map.Width) * _map.TileWidth;
                float y = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight;

                Rectangle tilesetRec = new Rectangle(_tileWidth * column, _tileHeight * row, _tileWidth, _tileHeight);

                _spriteBatch.Draw(_tileset, new Rectangle((int)x, (int)y, _tileWidth, _tileHeight), tilesetRec, Color.White);
            }


            _spriteBatch.End();
        }

    }
}
