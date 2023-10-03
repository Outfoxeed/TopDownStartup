using NaughtyAttributes;
using Game.Runtime.HealthSystem;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealthProxy, IHealth
{
    public IHealthComponent Health => _target;
    [SerializeField, Required] Health _target;

    public void TakeDamage(int amount) => _target.TakeDamage(amount);
    public void Kill() => _target.Kill();
    public void Heal(int amount) => _target.Heal(amount);
}
