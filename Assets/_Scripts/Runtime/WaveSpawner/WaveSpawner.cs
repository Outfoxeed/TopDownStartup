using System;
using Game.Runtime.Enemies;
using Game.Runtime.UpdateSystem;
using ScriptableObjectArchitecture;
using UnityEngine;
using Zenject;

namespace Game.Runtime.WaveSpawner
{
    public class WaveSpawner : IWaveSpawner, IUpdated
    {
        [Inject] private WaveSpawnerConfig _config;
        [Inject] private WavesData _wavesData;
        [Inject(Id = "WaveStarted")] private IntGameEvent _waveStartedEvent; 
        [Inject(Id = "WaveEnded")] private IntGameEvent _waveEndedEvent; 
        [field: Inject] public PlayerReference PlayerReference { get; }
        [field: Inject] public IEnemiesManager EnemiesManager { get; }

        public float SpawnRange => _config.SpawnRange;

        private int _currentWave;
        private IDisposable _updateSubscription;
        
        [Inject]
        public void Construct(IUpdateSystem updateSystem)
        {
            _currentWave = -1;
            StartNextWave();
            
            _updateSubscription = updateSystem.SubsribeToUpdate(this);
        }
        public void Deconstruct()
        {
            _updateSubscription?.Dispose();
            _updateSubscription = null;
        }

        public void Update(float deltaTime)
        {
            _wavesData.Waves[_currentWave].Update(deltaTime);
            if (_wavesData.Waves[_currentWave].IsFinished)
            {
                StartNextWave();
            }
        }

        private void StartNextWave()
        {
            if(_currentWave >= 0)
            {
                _waveEndedEvent.Raise(_currentWave);    
            }
            
            _currentWave++;
            if (_currentWave >= _wavesData.Waves.Length)
            {
                Debug.Log("Game Ended: No more waves");
                _updateSubscription?.Dispose();
                _updateSubscription = null;
                return;
            }
            
            _wavesData.Waves[_currentWave].Init(this);
            _waveStartedEvent.Raise(_currentWave);
        }
    }
}