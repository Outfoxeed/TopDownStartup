using UnityEngine;

namespace Game.Runtime.DamageIndicatorSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DamageIndicatorSystemConfig")]
    public class DamageIndicatorSystemConfig : ScriptableObject
    {
        [field: SerializeField] public FloatingTextHandler Prefab;
    }
}