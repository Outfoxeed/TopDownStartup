using Game.Runtime.Enemies;
using Game.Runtime.WaveSpawner.WaveCommands.SpawnEnemiesCommands;
using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public class SpawnOneEnemyCmd : SpawnEnemiesWaveCommand
    {
        public override bool IsFinished => _enemy.Health.IsDead;
        
        [SerializeField] private EnemyData _enemyData;

        private AIBrain _enemy;

#if UNITY_EDITOR
        public SpawnOneEnemyCmd()
        {
            _editorName = "Spawn One Enemy Cmd";
        }
#endif

        public override void Init(IWaveSpawner waveSpawner)
        {
            base.Init(waveSpawner);
            _enemy = SpawnEnemy(_enemyData);
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}