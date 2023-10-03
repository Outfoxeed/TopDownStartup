using System.ComponentModel;
using Game.Runtime.Enemies;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Runtime.Guns.Factory
{
    public class GunFactory : IGunFactory
    {
        [Inject] private IUpdateSystem _updateSystem;
        [Inject] private GunProjectileDict _gunSpriteDict;
        [Inject] private IEnemiesManager _enemiesManager;
        [Inject] private IPoolFactory _poolFactory;

        public IGun Create(IShooter owner, GunsType gunType)
        {
            //TODO: PoolFactory could be injected or at least created only once
            ObjectPool<Projectile> objectPool = _poolFactory.CreatePool<Projectile>(_gunSpriteDict.ProjectilePrefabDict[gunType]);
            
            return gunType switch
            {
                GunsType.Debug => new DebugGune(owner, _updateSystem, objectPool),
                GunsType.Axes => new AxeGun(owner, _updateSystem, objectPool),
                GunsType.Bible => new BibleGun(owner, _updateSystem, objectPool),
                GunsType.Knife => new KnifeGun(owner, _updateSystem, objectPool),
                GunsType.MagicWand => new WandGun(owner, _updateSystem, objectPool, _enemiesManager),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}