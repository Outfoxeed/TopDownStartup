using System;

namespace Game.Runtime.UnityCallbackSystems
{
    public interface IUnityCallbackSystem<TSubscriber>
    {
        IDisposable Subscribe(TSubscriber subscriber);
        void Unsubscribe(TSubscriber subscriber);

        public class UnityCallbackSubscriptionDisposable<TSubscriber> : IDisposable
        {
            private IUnityCallbackSystem<TSubscriber> _subscriptionProvider;
            private TSubscriber _subscriber;

            public UnityCallbackSubscriptionDisposable(IUnityCallbackSystem<TSubscriber> subscriptionProvider, TSubscriber subscriber)
            {
                _subscriptionProvider = subscriptionProvider;
                _subscriber = subscriber;
            }

            public void Dispose()
            {
                _subscriptionProvider.Unsubscribe(_subscriber);
            }
        }
    }
}