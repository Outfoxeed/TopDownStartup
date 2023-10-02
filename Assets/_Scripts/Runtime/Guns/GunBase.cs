using System;
using Game.Runtime.UpdateSystem;
using Zenject;

namespace Game.Runtime.Guns
{
    public abstract class GunBase : IGun
    {
        protected IDisposable _updateSubscription;

        [Inject]
        public virtual void Construct(IUpdateSystem updateSystem)
        {
            _updateSubscription = updateSystem.SubsribeToUpdate(this);
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