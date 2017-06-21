using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Draw
{

    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Draw,
        Layer = 1)]
    public class RenderStaticGraphicSystem: EntityProcessingSystem
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly ICameraManager _camera;

        public RenderStaticGraphicSystem(
            SpriteBatch spriteBatch,
            ICameraManager camera) 
            : base(Aspect.All(
                typeof(StaticGraphic),
                typeof(Position)))
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }
        public override void Process(Entity entity)
        {
            StaticGraphic staticGraphic = entity.GetComponent<StaticGraphic>();
            Position position = entity.GetComponent<Position>();
            Vector2 posVec = new Vector2(
                position.X, 
                position.Y);

            _spriteBatch.Draw(staticGraphic.Texture, posVec, Color.White);
        }
    }
}
