using Game.Runtime.Enemies;
using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands.SpawnEnemiesCommands
{
    public abstract class SpawnEnemiesWaveCommand : WaveCommand
    {
        protected IWaveSpawner _waveSpawner;
        
        public override void Init(IWaveSpawner waveSpawner)
        {
            _waveSpawner = waveSpawner;
        }

        public AIBrain SpawnEnemy(EnemyData enemyData)
        {
            AIBrain enemy = _waveSpawner.EnemiesManager.GetEnemyInstance();
            enemy.SetData(enemyData);
            
            Vector3 offset = new Vector3(
                x: UnityEngine.Random.Range(-1f, 1f),
                y: UnityEngine.Random.Range(-1f, 1f),
                z: 0
            ).normalized * _waveSpawner.SpawnRange;
            enemy.transform.position = _waveSpawner.PlayerReference.Instance.transform.position 
                                       + offset;
            return enemy;
        }
    }
}