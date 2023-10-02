using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Runtime.MusketeerEvents
{
    [System.Serializable]
    public class MusketeerEvent<T>
    {
        [SerializeField] private UnityEvent<T> _unityEvent;
        private event Action<T> _action;

        public void Invoke(T parameter)
        {
            _action?.Invoke(parameter);
            _unityEvent.Invoke(parameter);
        }

        public void AddListener(Action<T> action)
        {
            _action += action;
        }

        public void RemoveListener(Action<T> action)
        {
            _action -= action;
        }
        
        public static MusketeerEvent<T> operator +(MusketeerEvent<T> a, Action<T> b)
        {
            a._action += b;
            return a;
        }
        public static MusketeerEvent<T> operator -(MusketeerEvent<T> a, Action<T> b)
        {
            a._action -= b;
            return a;
        }
    }
}