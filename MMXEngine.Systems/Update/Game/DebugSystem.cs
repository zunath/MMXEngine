using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Microsoft.Xna.Framework.Media;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.Managers;

namespace MMXEngine.Systems.Update.Game
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class DebugSystem: EntitySystem
    {
        private readonly IInputManager _inputManager;

        public DebugSystem(IInputManager inputManager)
        {
            _inputManager = inputManager;
        }

        public override void Process()
        {
            // Toggle Music
            if (_inputManager.IsPressed(GameButton.ToggleMusic))
            {
                if(MediaPlayer.State == MediaState.Paused)
                    MediaPlayer.Resume();
                else if(MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Pause();
            }

        }

    }
}
