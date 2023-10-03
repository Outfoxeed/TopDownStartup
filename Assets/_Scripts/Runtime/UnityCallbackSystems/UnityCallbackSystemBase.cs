using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.UnityCallbackSystems
{
    public abstract class UnityCallbackSystemBase<TSubscriber> : MonoBehaviour, IUnityCallbackSystem<TSubscriber>
    {
        protected List<TSubscriber> _subscribers = new();

        public IDisposable Subscribe(TSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
            return new IUnityCallbackSystem<TSubscriber>
                .UnityCallbackSubscriptionDisposable<TSubscriber>(this, subscriber);
        }

        public void Unsubscribe(TSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}