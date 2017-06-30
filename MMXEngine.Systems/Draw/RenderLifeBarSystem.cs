using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderLifeBarSystem: EntitySystem
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly ICameraManager _camera;
        private readonly IContentManager _content;
        private Texture2D _texture;

        public RenderLifeBarSystem(SpriteBatch spriteBatch,
            ICameraManager camera,
            IContentManager content)
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
            _content = content;
        }

        public override void Process()
        {
            if(_texture == null)
                _texture = _content.Load<Texture2D>(".\\Graphics\\Items\\Items");

            Entity player = BlackBoard.GetEntry<Entity>("Player");
            Health hp = player.GetComponent<Health>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            
            Vector2 position = 
                new Vector2(
                    _camera.TopLeft.X + 20,
                    _camera.TopLeft.Y + 70);

            Rectangle sourceBottom = new Rectangle(2, 55, 14, 16);
            Rectangle sourceLife = new Rectangle(2, 51, 14, 2);
            Rectangle sourceEmpty = new Rectangle(2, 32, 14, 2);
            Rectangle sourceTop = new Rectangle(2, 13, 14, 4);

            if(character.CharacterType == CharacterType.Zero)
                sourceBottom = new Rectangle(50, 55, 14, 16);

            Vector2 origin = new Vector2(14.0f/2.0f, 3.0f/2.0f);

            _spriteBatch.Draw(_texture,
                position,
                sourceBottom,
                Color.White,
                0.0f,
                origin,
                1.0f,
                SpriteEffects.None,
                0);

            for (int x = 1; x <= hp.MaxHitPoints; x++)
            {
                Rectangle source = sourceLife;

                if (x > hp.CurrentHitPoints)
                    source = sourceEmpty;

                if(x == 1)
                    position = new Vector2(
                        position.X,
                        position.Y - 1);
                else 
                    position = new Vector2(
                        position.X,
                        position.Y - 2);

                _spriteBatch.Draw(_texture,
                    position,
                    source,
                    Color.White,
                    0.0f,
                    origin,
                    1.0f,
                    SpriteEffects.None, 
                    0);
            }

            position = new Vector2(
                position.X,
                position.Y - 4);

            _spriteBatch.Draw(_texture,
                position,
                sourceTop,
                Color.White,
                0.0f,
                origin,
                1.0f,
                SpriteEffects.None,
                0);
        }
    }
}
