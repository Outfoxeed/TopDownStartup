using Game.Runtime.HealthSystem;

public interface IHealthProxy : IHealth
{
    public IHealthComponent Health { get; }
}