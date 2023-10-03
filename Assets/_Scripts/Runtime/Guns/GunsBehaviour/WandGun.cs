using Codice.CM.Common;
using Game.Runtime.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Runtime.Guns
{
    public class WandGun : GunBase
    {
        private IEnemiesManager _enemiesManager;
        [SerializeField] private float speed = 5;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public WandGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Rigidbody2D> objPool, IEnemiesManager enemiesManager) : base(owner, updateSystem, objPool)
        {
            _enemiesManager = enemiesManager;
        }

        public override void Shoot()
        {
            AIBrain enemyBrain = _enemiesManager.GetClosestEnemy(_owner.Transform.position);

            if (enemyBrain == null)
                return;

            Vector2 dir = ((Vector2)enemyBrain.Transform.position - (Vector2)_owner.Transform.position).normalized;
            Vector2 move = dir * speed;

            Rigidbody2D projectile = _projectilePool.Get();
            projectile.transform.position = _owner.Transform.position;
            projectile.velocity = move;

            Do(projectile);
        }

        async Task Do(Rigidbody2D rb)
        {
            await Task.Delay(5000);
            _projectilePool.Release(rb);
        }

        public override void Update(float deltaTime)
        {
            chrono += deltaTime;
            if (chrono >= delay)
            {
                chrono = 0;
                Shoot();
            }
        }
    }
}
