using System.Collections.Generic;
using Game.Runtime.Enemies;

namespace Game.Runtime.WaveSpawner
{
    public interface IWaveSpawnerConfig
    {
        float SpawnRange { get; }
    }
}