using System;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class MovementSystem : EntityProcessingSystem
    {
        private IInputManager _inputManager;

        public MovementSystem(IInputManager inputManager) 
            : base(Aspect.All(typeof(Position), typeof(Physics)))
        {
            _inputManager = inputManager;
        }

        public override void Process(Entity entity)
        {
            Position position = entity.GetComponent<Position>();
            Physics physics = entity.GetComponent<Physics>();
            physics.CurrentSpeedX = physics.Acceleration*physics.TargetSpeed +
                                   (1 - physics.Acceleration)*physics.CurrentSpeedX;
            if (Math.Abs(physics.CurrentSpeedX) < 1.0f) physics.CurrentSpeedX = 0;
            if (Math.Abs(physics.CurrentSpeedY) < 1.0f) physics.CurrentSpeedY = 0;
            

        }
    }
}
