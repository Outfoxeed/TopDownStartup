using Game.Runtime.UnityCallbackSystems;
using Game.Runtime.UnityCallbackSystems.StartSystem;

namespace Game.Runtime.StartSystem
{
    public class StartSystem : UnityCallbackSystemBase<IStart>, IStartSystem
    {
        private void Start()
        {
            for (int i = 0; i < _subscribers.Count; i++)
            {
                _subscribers[i].Start();
            }
        }
    }
}