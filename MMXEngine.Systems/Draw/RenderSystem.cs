using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;

        public RenderSystem(SpriteBatch spriteBatch) 
            : base(Aspect.All(typeof(Renderable)))
        {
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            Renderable renderable = entity.GetComponent<Renderable>();
            SpriteEffects flip = SpriteEffects.None;
            Vector2 origin = new Vector2((int)(renderable.Source.Width / 2), (int)(renderable.Source.Height / 2));

            if (renderable.Facing == Direction.Left)
            {
                flip = SpriteEffects.FlipHorizontally;
            }
            
            _spriteBatch.Draw(renderable.Texture,                   // Texture
                renderable.Position,                                // Position
                renderable.Source,                                  // Source
                renderable.ColorOverride ?? Color.White,            // Color
                0.0f,                                               // Rotation
                origin,                                             // Origin 
                1.0f,                                               // Scale
                flip,                                               // SpriteEffects
                0.0f);                                              // Layer Depth
        }
    }
}
