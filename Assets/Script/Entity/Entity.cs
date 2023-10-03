using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Game.Runtime.HealthSystem;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public IHealthComponent Health => _health;
    [SerializeField, Required("nop")] Health _health;
}
