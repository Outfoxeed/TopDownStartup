using UnityEngine;

namespace Game.Runtime.WaveSpawner
{
    [CreateAssetMenu(fileName = "WaveSpawner Config", menuName = "Config/WaveSpawner", order = 0)]
    public class WaveSpawnerConfig : ScriptableObject, IWaveSpawnerConfig
    {
        [field: SerializeField] public float SpawnRange { get; private set; }
    }
}