namespace MMXEngine.ECS.Data
{
    public class PlayerData: CreatureData
    {
        public float MaxDashLength { get; set; }
        public float MaxJumpLength { get; set; }
        public float MoveSpeed { get; set; }
        public float DashSpeed { get; set; }
        public float JumpSpeed { get; set; }
        public float MaxFallSpeed { get; set; }
        public float GravitySpeed { get; set; }
    }
}
