using Game.Runtime.Enemies;

namespace Game.Runtime.WaveSpawner
{
    public interface IWaveSpawner : IWaveSpawnerConfig
    {
        public PlayerReference PlayerReference { get; }
        public IEnemiesManager EnemiesManager { get; }
    }
}