using System;

namespace Game.Runtime.HealthSystem
{
    public interface IHealthComponent : IHealth
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        bool IsDead { get; }
        event Action<int> Damaged;
        event Action<int> Healed;
        event Action Death;
        float GetHealthPercentage();
        void Reset(int? maxHealth = null);
    }
}