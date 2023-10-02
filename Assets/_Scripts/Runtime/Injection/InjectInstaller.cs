using System;
using Game.Runtime.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game
{
    public class InjectInstaller : MonoInstaller
    {
        [SerializeField] private UpdateSystem _updateSystem;
        [SerializeField] private PlayerReference _playerReference;
        public override void InstallBindings()
        {
            // Scriptable
            Container.Bind<PlayerReference>().FromInstance(_playerReference).AsSingle();
            
            //Container.Bind<Patate>().AsSingle().NonLazy();
            Container.Bind<IUpdateSystem>().FromComponentInNewPrefab(_updateSystem).AsSingle().NonLazy();

            Container.Bind<PoolManager>().AsSingle().NonLazy();
        }
    }
}
