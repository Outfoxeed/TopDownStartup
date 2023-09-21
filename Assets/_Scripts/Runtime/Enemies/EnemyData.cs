using UnityEngine;

namespace Game.Runtime.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; private set; } = 1;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 10f;
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}