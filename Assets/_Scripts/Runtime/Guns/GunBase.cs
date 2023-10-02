using System;
using Game.Runtime.UpdateSystem;
using Zenject;

namespace Game.Runtime.Guns
{
    public abstract class GunBase : IGun
    {
        protected IDisposable _updateSubscription;
        protected IShooter _owner;

        protected GunBase(IShooter owner, IUpdateSystem updateSystem)
        {
            _owner = owner;
            _updateSubscription = updateSystem.SubsribeToUpdate(this);
        }

        public void Deconstruct()
        {
            _updateSubscription.Dispose();
            _updateSubscription = null;
        }

        public abstract void Shoot(IShooter source);
        public abstract void Update(float deltaTime);
    }
}