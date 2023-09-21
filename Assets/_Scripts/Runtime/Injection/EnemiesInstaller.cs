using Game.Runtime.Enemies;
using Game.Runtime.WaveSpawner;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Injection
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private AIBrain _enemyPrefab;
        [SerializeField] private WaveSpawnerConfig _waveSpawnerConfig;
        [SerializeField] private WavesData _wavesData;
        
        public override void InstallBindings()
        {
            // Prefabs
            if (_enemyPrefab == null)
            {
                Debug.Log("uifehgiuheiufhui");
            }
            Container.Bind<AIBrain>().FromInstance(_enemyPrefab).AsSingle();
            
            // Scriptable objects
            Container.Bind<WaveSpawnerConfig>().FromInstance(_waveSpawnerConfig).AsSingle();
            Container.Bind<WavesData>().FromInstance(_wavesData).AsSingle();
            
            // Systems
            Container.Bind<IEnemiesManager>().To<EnemiesManager>().AsSingle().NonLazy();
            Container.Bind<IWaveSpawner>().To<WaveSpawner.WaveSpawner>().AsSingle().NonLazy();
        }
    }
}