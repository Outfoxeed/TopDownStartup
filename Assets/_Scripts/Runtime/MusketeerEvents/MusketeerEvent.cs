using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Runtime.MusketeerEvents
{
    [System.Serializable]
    public class MusketeerEvent
    {
        [SerializeField] private UnityEvent _unityEvent;
        private event Action _action;

        public void Invoke()
        {
            _action?.Invoke();
            _unityEvent.Invoke();
        }
        
        public void AddListener(Action action)
        {
            _action += action;
        }

        public void RemoveListener(Action action)
        {
            _action -= action;
        }

        public void Clear() => _action = null;
        
        public static MusketeerEvent operator +(MusketeerEvent a, Action b)
        {
            a._action += b;
            return a;
        }        
        public static MusketeerEvent operator -(MusketeerEvent a, Action b)
        {
            a._action -= b;
            return a;
        }
    }
}