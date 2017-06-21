using Artemis.Interface;
using MMXEngine.Common.Enumerations;

namespace MMXEngine.ECS.Components
{
    public class PlayerCharacter : IComponent
    {
        public CharacterType CharacterType { get; set; }

        public bool WasDashingLastFrame { get; set; }
        public bool IsDashing { get; set; }
        public float CurrentDashLength { get; set; }
        public float MaxDashLength { get; set; }

        public bool WasJumpingLastFrame { get; set; }
        public bool IsJumping { get; set; }
        public float CurrentJumpLength { get; set; }
        public float MaxJumpLength { get; set; }

        public bool WasLandingLastFrame { get; set; }
        public bool IsLanding { get; set; }

        public float MoveSpeed { get; set; }
        public float DashSpeed { get; set; }
        public float JumpSpeed { get; set; }

        public bool WasShootingLastFrame { get; set; }
        public bool IsShooting { get; set; }

        public int CurrentNumberOfJumps { get; set; }
        public int MaxNumberOfJumps { get; set; }
    }
}
