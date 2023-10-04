using Game.Runtime.DamageIndicatorSystem;
using Game.Runtime.Enemies;
using Game.Runtime.GunGenerator;
using Game.Runtime.Guns.Factory;
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
        [SerializeField] private GunGeneratorConfig _gunGeneratorConfig;
        [SerializeField] private DamageIndicatorSystemConfig _damageIndicatorSystemConfig;
        
        public override void InstallBindings()
        {
            // Prefabs
            Container.Bind<AIBrain>().FromInstance(_enemyPrefab).AsSingle();
            
            // Scriptable objects
            Container.Bind<WaveSpawnerConfig>().FromInstance(_waveSpawnerConfig).AsSingle();
            Container.Bind<WavesData>().FromInstance(_wavesData).AsSingle();
            Container.Bind<GunGeneratorConfig>().FromInstance(_gunGeneratorConfig).AsSingle();
            Container.Bind<DamageIndicatorSystemConfig>().FromInstance(_damageIndicatorSystemConfig).AsSingle();
            
            // Factories
            Container.Bind<IGunFactory>().To<GunFactory>().AsSingle().NonLazy();
            
            // Systems
            Container.Bind<IEnemiesManager>().To<EnemiesManager>().AsSingle().NonLazy();
            Container.Bind<IWaveSpawner>().To<WaveSpawner.WaveSpawner>().AsSingle().NonLazy();
            Container.Bind<IGunGenerator>().To<GunGenerator.GunGenerator>().AsSingle().NonLazy();
            Container.Bind<IDamageIndicatorSystem>().To<DamageIndicatorSystem.DamageIndicatorSystem>().AsSingle()
                .NonLazy();
        }
    }
}