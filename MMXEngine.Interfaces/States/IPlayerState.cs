using Artemis;

namespace MMXEngine.Contracts.States
{
    public interface IPlayerState
    {
        void HandleInput(Entity player);
        void EnterState(Entity player);
        void ExitState(Entity player);
        void ProcessState(Entity player);
    }
}
