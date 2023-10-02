using System;
using Game.Runtime.Guns;
using Game.Runtime.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game
{
    public class InjectInstaller : MonoInstaller
    {
        [SerializeField] private UpdateSystem _updateSystem;
        [SerializeField] private PlayerReference _playerReference;
        [SerializeField] private GunProjectileDict _gunSpriteDict;
        public override void InstallBindings()
        {
            // Scriptable
            Container.Bind<PlayerReference>().FromInstance(_playerReference).AsSingle();
            Container.Bind<GunProjectileDict>().FromInstance(_gunSpriteDict).AsSingle();

            //Container.Bind<Patate>().AsSingle().NonLazy();
            Container.Bind<IUpdateSystem>().FromComponentInNewPrefab(_updateSystem).AsSingle().NonLazy();

            Container.Bind<PoolManager>().AsSingle().NonLazy();
        }
    }
}
