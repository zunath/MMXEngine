namespace MMXEngine.Interfaces.Components
{
    public interface IHealthComponent
    {
        int CurrentHitPoints { get; set; }
        int MaxHitPoints { get; set; }
    }
}
