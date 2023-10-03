using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.StartSystem
{
    public class StartSystem : MonoBehaviour, IStartSystem
    {
        private List<IStart> _subscribers = new();

        private void Start()
        {
            for (int i = 0; i < _subscribers.Count; i++)
            {
                _subscribers[i].Start();
            }
        }

        public IDisposable SubscribeToStart(IStart subscriber)
        {
            _subscribers.Add(subscriber);
            return new IStartSystem.StartSubscriptionDisposable(this, subscriber);
        }

        public void UnsubscribeToStart(IStart subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}