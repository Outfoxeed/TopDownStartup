using UnityEngine;

namespace Game.Runtime.DamageIndicatorSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DamageIndicatorSystemConfig")]
    public class DamageIndicatorSystemConfig : ScriptableObject
    {
        [field: SerializeField] public FloatingTextHandler Prefab;
        [field: SerializeField] public int InstanceMaxCapacity { get; private set; } = 50;
    }
}