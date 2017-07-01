using System.Collections.Generic;
using Artemis.Interface;
using MMXEngine.Common.Enumerations;
using MMXEngine.Contracts.States;

namespace MMXEngine.ECS.Components
{
    public class PlayerStateMap: IComponent
    {
        public PlayerState PreviousState { get; set; }
        public PlayerState CurrentState { get; set; }
        public Dictionary<PlayerState, IPlayerState> States { get; set; }

        public PlayerStateMap()
        {
            States = new Dictionary<PlayerState, IPlayerState>();
        }
    }
}
