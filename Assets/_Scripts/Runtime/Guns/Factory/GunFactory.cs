using System.ComponentModel;
using Game.Runtime.UpdateSystem;
using Zenject;

namespace Game.Runtime.Guns.Factory
{
    public class GunFactory : IGunFactory
    {
        [Inject] private IUpdateSystem _updateSystem;
        [Inject] private PoolManager _poolManager;
        [Inject] private GunProjectileDict _gunSpriteDict;

        public IGun Create(IShooter owner, GunsType gunType)
        {
            return gunType switch
            {
                GunsType.Debug => new DebugGune(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Axes => new AxeGun(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Bible => new BibleGun(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.Knife => new KnifeGun(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                GunsType.MagicWand => new DebugGune(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType])),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}