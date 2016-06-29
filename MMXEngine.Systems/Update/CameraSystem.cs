using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework;
using MMXEngine.Common.Attributes;
using MMXEngine.Common.Enumerations;
using MMXEngine.ECS.Components;
using MMXEngine.Interfaces.Managers;

namespace MMXEngine.Systems.Update
{
    [LoadableSystem(7)]
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
            _cameraManager.Focus = new Vector2(position.X, position.Y);
        }
    }
}
