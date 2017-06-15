using Artemis;

namespace MMXEngine.Contracts.States
{
    public interface IPlayerState
    {
        void EnterState(Entity player);
        void ExitState(Entity player);
        void ProcessState(Entity player);
    }
}
