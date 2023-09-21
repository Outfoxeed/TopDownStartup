using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    [SerializeField, Required] Health _target;

    public void TakeDamage(int amount) => _target.TakeDamage(amount);
    public void Kill() => _target.Kill();
    public void Heal(int amount) => _target.Heal(amount);

}
