using UnityEngine;

namespace Game.Runtime.UnityCallbackSystems.UpdateSystem
{
    public class UpdateSystem : UnityCallbackSystemBase<IUpdate>, IUpdateSystem
    {
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _subscribers.Count; i++)
            {
                _subscribers[i].Update(deltaTime);
            }
        }
    }
}