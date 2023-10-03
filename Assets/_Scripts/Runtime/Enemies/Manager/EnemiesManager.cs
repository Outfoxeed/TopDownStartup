using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Runtime.Enemies
{
    public class EnemiesManager : IEnemiesManager
    {
        private IObjectPool<AIBrain> _enemiesPool;
        private List<AIBrain> _enemies = new(); 
        
        [Inject]
        public void Construct(AIBrain prefab, IPoolFactory poolFactory)
        {
            _enemiesPool = poolFactory.CreatePool<AIBrain>(prefab.gameObject);
        }

        public AIBrain GetClosestEnemy(Vector2 worldPosition)
        {
            if(_enemies.Count == 0) return null;

            return _enemies.OrderBy(GetSquaredDistance).First();

            float GetSquaredDistance(IEnemy enemy)
            {
                Vector2 enemyPos = enemy.Transform.position;
                return Mathf.Pow(enemyPos.x - worldPosition.x, 2) + Mathf.Pow(enemyPos.y - worldPosition.y, 2);
            }
        }

        public AIBrain GetEnemyInstance()
        {
            AIBrain enemyInstance = _enemiesPool.Get();
            _enemies.Add(enemyInstance);
            enemyInstance.Disabled.Clear();
            enemyInstance.Disabled.AddListener(() =>
            {
                _enemiesPool.Release(enemyInstance);
                _enemies.Remove(enemyInstance);
            });
            return enemyInstance;
        }

        public void RemoveAllEnemies()
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].gameObject.SetActive(false);
            }
            _enemies.Clear();
        }
    }
}