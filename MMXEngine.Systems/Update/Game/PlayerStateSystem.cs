using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using MMXEngine.Contracts.Managers;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.Systems.Update.Game
{
    [ArtemisEntitySystem(
        ExecutionType = ExecutionType.Synchronous,
        GameLoopType = GameLoopType.Update,
        Layer = 1)]
    public class PlayerStateSystem : EntityProcessingSystem
    {
        private readonly IInputManager _inputManager;
        private readonly EntityWorld _world;
        
        public PlayerStateSystem(IInputManager inputManager,
            EntityWorld world) 
            : base(Aspect.All(typeof(PlayerStateMap)))
        {
            _inputManager = inputManager;
            _world = world;
        }

        public override void Process(Entity entity)
        {
            PlayerStateMap stateMap = entity.GetComponent<PlayerStateMap>();
            stateMap.PreviousState = stateMap.CurrentState;

            foreach (var state in stateMap.States)
            {
                state.Value.HandleInput(entity);
            }
            
            if (stateMap.CurrentState != stateMap.PreviousState)
            {
                stateMap.States[stateMap.PreviousState].ExitState(entity);
                stateMap.States[stateMap.CurrentState].EnterState(entity);
            }
            
            IPlayerState finalState = stateMap.States[stateMap.CurrentState];
            finalState.ProcessState(entity);
        }
    }
}
