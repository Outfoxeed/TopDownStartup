using Game.Runtime.Enemies;
using Game.Runtime.WaveSpawner.WaveCommands.SpawnEnemiesCommands;
using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public class SpawnEnemiesForDurationCommand : SpawnEnemiesWaveCommand
    {
        public override bool IsFinished => _isFinished;
        
        [SerializeField] private float _duration;
        [SerializeField] private float _spawnPerSecond;
        private float _spawnCooldown;
        private float _lastSpawnTime;

        [SerializeField] private EnemyData[] _enemies;
        
        private float _startTime;
        private bool _isFinished;

        public override void Init(IWaveSpawner waveSpawner)
        {
            base.Init(waveSpawner);
            _isFinished = false;
            _startTime = Time.time;
            _spawnCooldown = 1f / _spawnPerSecond;
            _lastSpawnTime = float.MinValue;
        }

        public override void Update(float deltaTime)
        {
            // Set finished to true after '_duration' seconds
            if (Time.time - _startTime >= _duration)
            {
                _isFinished = true;
                return;
            }

            // Do not spawn new enemy if cooldown not ready
            if (Time.time - _lastSpawnTime < _spawnCooldown)
            {
                return;
            }
            
            _lastSpawnTime = Time.time;
            SpawnEnemy(GetRandomEnemyData());
        }

        public EnemyData GetRandomEnemyData() 
            => _enemies[UnityEngine.Random.Range(0, _enemies.Length)];
    }
}