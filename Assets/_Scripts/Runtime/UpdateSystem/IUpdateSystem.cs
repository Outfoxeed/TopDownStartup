using System;

namespace Game.Runtime.UpdateSystem
{
    public interface IUpdateSystem
    {
        public IDisposable SubsribeToUpdate(IUpdate subscriber);
        public void UnsubscribeToUpdate(IUpdate subscriber);

        public class UpdateSubscriptionDisposable : IDisposable
        {
            private IUpdateSystem _updateSystem;
            private IUpdate _subscriber;

            public UpdateSubscriptionDisposable(IUpdateSystem updateSystem, IUpdate subscriber)
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