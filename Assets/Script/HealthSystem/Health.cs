using Game.Runtime.HealthSystem;
using Game.Runtime.MusketeerEvents;
using NaughtyAttributes;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Assertions;

public class Health : MonoBehaviour, IHealthComponent, IHealth
{
    [SerializeField] private IntReference _maxHealthRef;
    
    public int MaxHealth
    {
        get => _maxHealthRef.Value;
        private set => _maxHealthRef.Value = value;
    }

    [SerializeField, ReadOnly] 
    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            HealthUpdated.Invoke(_currentHealth);
        }
    }

    public bool IsDead => CurrentHealth <= 0;

    [field: SerializeField] public MusketeerEvent<int> HealthUpdated { get; private set; }
    [field: SerializeField] public MusketeerEvent<int> Damaged { get; private set; } = new();
    [field: SerializeField] public MusketeerEvent<int> Healed { get; private set; } = new();
    [field: SerializeField] public MusketeerEvent Death { get; private set; } = new();

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public float GetHealthPercentage() => CurrentHealth / (float)MaxHealth;

    public void TakeDamage(int amount)
    {
        Assert.IsTrue(amount >= 0);
        if (IsDead) return;

        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        Damaged?.Invoke(amount);
        if (IsDead)
        {
            InternalDie();
        }
    }

    public void Reset(int? maxHealth = null)
    {
        if (maxHealth is {} newMaxHealth)
        {
            MaxHealth = newMaxHealth;
        }

        CurrentHealth = MaxHealth;
    }


    public void Heal(int amount)
    {
        Assert.IsTrue(amount >= 0);
        if (IsDead) return;
        InternalHeal(amount);
    }
    void InternalHeal(int amount)
    {
        Assert.IsTrue(amount >= 0);

        var old = CurrentHealth;
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        Healed?.Invoke(CurrentHealth - old);
    }
    
    public void Kill()
    {
        if (IsDead) return;
        CurrentHealth = 0;
        InternalDie();
    }
    void InternalDie()
    {
        if (!IsDead) return;
        Death?.Invoke();
    }

#if UNITY_EDITOR
    [Button("TakeDamage")]
    private void Editor_TakeDamage() => TakeDamage(1);

    [Button("Die")]
    private void Editor_Die() => Kill();
#endif
}
