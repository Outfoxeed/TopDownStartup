using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class AwakeCallback : MonoBehaviour
    {
        [SerializeField] private UnityEvent _awakeCallback;

        private void Awake()
        {
            _awakeCallback.Invoke();
        }
    }
}
