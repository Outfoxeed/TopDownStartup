using System.ComponentModel;
using Game.Runtime.Enemies;
using Game.Runtime.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Guns.Factory
{
    public class GunFactory : IGunFactory
    {
        [Inject] private IUpdateSystem _updateSystem;
        [Inject] private GunProjectileDict _gunSpriteDict;
        [Inject] private IEnemiesManager _enemiesManager;

        public IGun Create(IShooter owner, GunsType gunType)
        {
            PoolFactory poolFactory = new PoolFactory();
                
            return gunType switch
            {
                GunsType.Debug => new DebugGune(owner, _updateSystem, poolFactory.CreatePool(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Axes => new AxeGun(owner, _updateSystem, poolFactory.CreatePool(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Bible => new BibleGun(owner, _updateSystem, poolFactory.CreatePool(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Knife => new KnifeGun(owner, _updateSystem, poolFactory.CreatePool(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.MagicWand => new WandGun(owner, _updateSystem, poolFactory.CreatePool(_gunSpriteDict.ProjectilePrefabDict[gunType]), _enemiesManager),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}