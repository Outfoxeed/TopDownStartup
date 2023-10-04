using Game.Runtime.HealthSystem;
using NaughtyAttributes;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public IHealthComponent Health => _health;
    [SerializeField, Required("nop")] Health _health;
}
