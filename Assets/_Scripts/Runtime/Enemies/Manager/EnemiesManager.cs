using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Enemies
{
    public class EnemiesManager : IEnemiesManager
    {
        // TODO: Pools Manager
        
        private AIBrain _prefab;
        private List<AIBrain> _enemies = new(); 
        
        //TODO: remove
        [Inject] public PlayerReference PlayerRef;

        [Inject]
        public void Construct(AIBrain prefab)
        {
            _prefab = prefab;
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
            AIBrain newInstance = Object.Instantiate(_prefab);
            _enemies.Add(newInstance);
            return newInstance;
        }

        public void RemoveAllEnemies()
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                Object.Destroy(_enemies[i].gameObject);
            }

            _enemies.Clear();
        }
    }
}