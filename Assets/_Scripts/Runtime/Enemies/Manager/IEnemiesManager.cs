using UnityEngine;

namespace Game.Runtime.Enemies
{
    public interface IEnemiesManager
    {
        public AIBrain GetClosestEnemy(Vector2 worldPosition);
        public AIBrain GetEnemyInstance();
        public void RemoveAllEnemies();
    }
}