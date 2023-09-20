using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class InjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<Patate>().AsSingle().NonLazy();
        }
    }
}
