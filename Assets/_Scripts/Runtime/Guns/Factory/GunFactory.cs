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
            return new DebugGune(owner, _updateSystem, _poolManager.Get(_gunSpriteDict.ProjectilePrefabDict[gunType]));

            //return gunType switch
            //{
            //    GunsType.Debug => new DebugGune(owner, _updateSystem, _poolManager.Get(new UnityEngine.GameObject(""))), //TODO : Replace by Scriptable that contains projectile prefab
            //    _ => throw new InvalidEnumArgumentException()
            //};
        }
    }
}