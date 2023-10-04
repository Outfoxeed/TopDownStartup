using System;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine.Pool;

namespace Game.Runtime.Guns
{
    public abstract class GunBase : IGun
    {
        protected IDisposable _updateSubscription;
        protected IShooter _owner;
        protected ObjectPool<Projectile> _projectilePool;

        protected GunBase(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Projectile> objPool)
        {
            _owner = owner;
            _updateSubscription = updateSystem.Subscribe(this);
            _projectilePool = objPool;
        }

        public void Deconstruct()
        {
            _updateSubscription.Dispose();
            _updateSubscription = null;
        }

        public abstract void Shoot();
        public abstract void Update(float deltaTime);
    }
}