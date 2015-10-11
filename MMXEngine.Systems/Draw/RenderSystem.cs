using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Draw
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderSystem: EntityProcessingSystem
    {
        private readonly ICameraManager _cameraManager;
        private readonly SpriteBatch _spriteBatch;

        public RenderSystem(ICameraManager cameraManager, SpriteBatch spriteBatch) 
            : base(Aspect.All(typeof(Renderable)))
        {
            _cameraManager = cameraManager;
            _spriteBatch = spriteBatch;
        }

        public override void Process(Entity entity)
        {
            Renderable renderable = entity.GetComponent<Renderable>();

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _cameraManager.Transform);
            _spriteBatch.Draw(renderable.Texture, renderable.Position, renderable.Source, Color.White);
            _spriteBatch.End();
        }
    }
}
