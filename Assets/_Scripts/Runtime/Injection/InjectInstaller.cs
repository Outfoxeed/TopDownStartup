using System;
using Game.Runtime.Guns;
using Game.Runtime.StartSystem;
using Game.Runtime.UnityCallbackSystems.StartSystem;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game
{
    public class InjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _unityCallbackSystemsPrefab;
        [SerializeField] private PlayerReference _playerReference;
        [SerializeField] private GunProjectileDict _gunProjectileDict;
        public override void InstallBindings()
        {
            // Scriptable
            Container.Bind<PlayerReference>().FromInstance(_playerReference).AsSingle();
            Container.Bind<GunProjectileDict>().FromInstance(_gunProjectileDict).AsSingle();

            //Container.Bind<Patate>().AsSingle().NonLazy();
            Container.Bind(typeof(IUpdateSystem), typeof(IStartSystem)).FromComponentInNewPrefab(_unityCallbackSystemsPrefab).AsSingle().NonLazy();

            Container.Bind<IPoolFactory>().To<PoolFactory>().AsSingle().NonLazy();
        }
    }
}
