using System;

namespace Game.Runtime.UpdateSystem
{
    public interface IUpdateSystem
    {
        public IDisposable SubsribeToUpdate(IUpdated subscriber);
        public void UnsubscribeToUpdate(IUpdated subscriber);

        public class UpdateSubscriptionDisposable : IDisposable
        {
            private IUpdateSystem _updateSystem;
            private IUpdated _subscriber;

            public UpdateSubscriptionDisposable(IUpdateSystem updateSystem, IUpdated subscriber)
            {
                _updateSystem = updateSystem;
                _subscriber = subscriber;
            }

            public void Dispose()
            {
                _updateSystem.UnsubscribeToUpdate(_subscriber);
            }
        }
    }
}