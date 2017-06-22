using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Contracts.Managers;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class CameraSystem: EntitySystem
    {
        private readonly ICameraManager _cameraManager;

        public CameraSystem(ICameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        public override void Process()
        {
            Entity player = (Entity)BlackBoard.GetEntry("Player");
            if (player == null) return;

            Position position = player.GetComponent<Position>();
            _cameraManager.Focus(position.X, position.Y+30);
        }
    }
}
