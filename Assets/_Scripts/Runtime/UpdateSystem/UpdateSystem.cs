using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.UpdateSystem
{
    public class UpdateSystem : MonoBehaviour, IUpdateSystem
    {
        private List<IUpdated> _subsribers = new ();

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _subsribers.Count; i++)
            {
                _subsribers[i].Update(deltaTime);
            }
        }

        public IDisposable SubsribeToUpdate(IUpdated subscriber)
        {
            _subsribers.Add(subscriber);
            return new IUpdateSystem.UpdateSubscriptionDisposable(this, subscriber);
        }

        public void UnsubscribeToUpdate(IUpdated subscriber)
        {
            _subsribers.Remove(subscriber);
        }
    }
}