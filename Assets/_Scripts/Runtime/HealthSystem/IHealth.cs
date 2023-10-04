using Game.Runtime.MusketeerEvents;

namespace Game.Runtime.HealthSystem
{
    public interface IHealthComponent : IHealth
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        bool IsDead { get; }
        MusketeerEvent<int> Damaged { get; }
        MusketeerEvent<int> Healed { get; }
        MusketeerEvent Death { get; }
        float GetHealthPercentage();
        void Reset(int? maxHealth = null);
    }
}