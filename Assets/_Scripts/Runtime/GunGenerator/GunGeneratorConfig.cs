using System;
using UnityEngine;

namespace Game.Runtime.GunGenerator
{
    [CreateAssetMenu(fileName = "GunGeneratorConfig", menuName = "ScriptableObjects/GunGeneratorConfig", order = 0)]
    public class GunGeneratorConfig : ScriptableObject
    {
        [field: SerializeField] public float GunGenerationCooldown { get; private set; } = 30f;
    }
}