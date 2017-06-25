using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class DebugTextSystem: EntityProcessingSystem
    {
        private readonly ICameraManager _camera;

        public DebugTextSystem(ICameraManager camera)
            : base(Aspect.All(typeof(VisibleText),
                typeof(Position)))
        {
            _camera = camera;
        }

        public override void Process(Entity entity)
        {
            Position textPosition = entity.GetComponent<Position>();
            textPosition.X = _camera.TopLeft.X;
            textPosition.Y = _camera.TopLeft.Y;

            Entity player = BlackBoard.GetEntry<Entity>("Player");
            Velocity velocity = player.GetComponent<Velocity>();
            Position position = player.GetComponent<Position>();
            PlayerStateMap stateMap = player.GetComponent<PlayerStateMap>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            string text = $"VelocityX: {velocity.X}\n" +
                          $"VelocityY: {velocity.Y}\n" +
                          $"PosX: {position.X}\n" +
                          $"PosY: {position.Y}\n" +
                          $"CurrentState: {stateMap.CurrentState}\n" +
                          $"IsWallSliding: {character.IsWallSliding}\n";

            VisibleText textComponent = entity.GetComponent<VisibleText>();
            textComponent.Message = text;

        }

    }
}
