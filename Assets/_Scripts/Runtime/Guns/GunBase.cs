using System;
using Game.Runtime.UpdateSystem;
using Zenject;

namespace Game.Runtime.Guns
{
    public abstract class GunBase : IGun
    {
        protected IDisposable _updateSubscription;
        protected IShooter _owner;
        protected PoolData _projectilePool;

        protected GunBase(IShooter owner, IUpdateSystem updateSystem, PoolData objPool)
        {
            _owner = owner;
            _updateSubscription = updateSystem.SubsribeToUpdate(this);
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