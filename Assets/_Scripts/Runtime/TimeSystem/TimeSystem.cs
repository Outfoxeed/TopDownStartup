using System;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using ScriptableObjectArchitecture;
using Zenject;

namespace Game.Runtime.TimeSystem
{
    public class TimeSystem : ITimeSystem, IUpdate
    {
        [Inject(Id="GameTime")] private FloatVariable _gameTime;
        private IDisposable _updateSubscription;
        
        [Inject]
        private void Construct(IUpdateSystem updateSystem)
        {
            _updateSubscription = updateSystem.Subscribe(this);
            _gameTime.Value = 0;
        }
        public void Deconstruct()
        {
            _updateSubscription?.Dispose();
            _updateSubscription = null;
        }

        public float GetTime() => _gameTime.Value;
        public void Update(float deltaTime)
        {
            _gameTime.Value += deltaTime;
        }
    }
}