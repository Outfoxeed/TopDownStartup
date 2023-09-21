using Game.Runtime.WaveSpawner.WaveCommands;
using UnityEngine;

namespace Game.Runtime.WaveSpawner
{
    [CreateAssetMenu(fileName = "New WavesData", menuName = "Waves Data", order = 0)]
    public class WavesData : ScriptableObject
    {
        [field: SerializeReference]
        public WaveCommand[] Waves { get; private set; }
    }
}