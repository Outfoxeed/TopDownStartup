using System;

namespace Game.Runtime.StartSystem
{
    public interface IStartSystem
    {
        public IDisposable SubscribeToStart(IStart subscriber);
        public void UnsubscribeToStart(IStart subscriber);

        public class StartSubscriptionDisposable : IDisposable
        {
            private IStartSystem _startSystem;
            private IStart _subscriber;

            public StartSubscriptionDisposable(IStartSystem startSystem, IStart subscriber)
            {
                _startSystem = startSystem;
                _subscriber = subscriber;
            }

            public void Dispose()
            {
                _startSystem.UnsubscribeToStart(_subscriber);
            }
        }
    }
}