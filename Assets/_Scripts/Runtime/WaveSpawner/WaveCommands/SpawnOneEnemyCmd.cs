using Game.Runtime.Enemies;
using UnityEngine;

namespace Game.Runtime.WaveSpawner.WaveCommands
{
    [System.Serializable]
    public class SpawnOneEnemyCmd : WaveCommand
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
            _enemy = waveSpawner.EnemiesManager.GetEnemyInstance();
            _enemy.SetData(_enemyData);
            
            Vector3 offset = new Vector3(
                x: UnityEngine.Random.Range(0f, 1f),
                y: UnityEngine.Random.Range(0f, 1f),
                z: 0
            ).normalized * waveSpawner.SpawnRange;
            _enemy.transform.position = waveSpawner.PlayerReference.Instance.transform.position + offset;
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}