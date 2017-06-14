using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Common.Constants;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class GravitySystem: EntityProcessingSystem
    {
        private IInputManager _inputManager;

        public GravitySystem(IInputManager inputManager) 
            : base(Aspect.All(typeof(Velocity), typeof(Position)))
        {
            _inputManager = inputManager;
        }

        public override void Process(Entity entity)
        {
            Position position = entity.GetComponent<Position>();
            Velocity velocity = entity.GetComponent<Velocity>();

            velocity.Y += WorldConstants.Gravity;
            if (velocity.Y > WorldConstants.Gravity) velocity.Y = WorldConstants.Gravity;
        }
    }
}
