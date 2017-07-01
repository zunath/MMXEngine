using Artemis;
using MMXEngine.Common.Enumerations;
using MMXEngine.Common.Extensions;
using MMXEngine.Contracts.States;
using MMXEngine.ECS.Components;

namespace MMXEngine.ECS.States.Player
{
    public class LandState: IPlayerState
    {
        private float _currentLandingTime;
        private const float LandingTime = 0.05f;
        private readonly EntityWorld _world;

        public LandState(EntityWorld world)
        {
            _world = world;
        }

        public void HandleInput(Entity player)
        {
            PlayerStateMap map = player.GetComponent<PlayerStateMap>();
            Position position = player.GetComponent<Position>();
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();

            if (!position.WasOnGroundLastFrame && 
                position.IsOnGround &&
                !character.IsJumping)
            {
                map.CurrentState = PlayerState.Land;
            }
        }

        public void EnterState(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.SetCurrentAnimation("Land");
            character.IsLanding = true;
        }

        public void ExitState(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            character.IsLanding = false;
        }

        public void ProcessState(Entity player)
        {
            PlayerCharacter character = player.GetComponent<PlayerCharacter>();
            _currentLandingTime += _world.DeltaSeconds();

            if (_currentLandingTime > LandingTime)
            {
                character.IsLanding = false;
                _currentLandingTime = 0.0f;
            }
        }
    }
}
