using Game.Runtime.Entities;
using Game.Runtime.HealthSystem;

namespace Game.Runtime.Enemies
{
    public interface IEnemy : IHasTransform
    {
        public IHealthComponent Health { get; }
        public EntityGfx Gfx { get; }
        public void SetData(EnemyData enemyData);
    }
}