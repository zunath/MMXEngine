using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class SpriteRenderSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public SpriteRenderSystem(Aspect aspect, 
            SpriteBatch spriteBatch)
            : base(Aspect.All(typeof(Sprite)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            Sprite sprite = entity.GetComponent<Sprite>();

            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, sprite.Position, Color.White);
            _spriteBatch.End();

        }
    }
}
