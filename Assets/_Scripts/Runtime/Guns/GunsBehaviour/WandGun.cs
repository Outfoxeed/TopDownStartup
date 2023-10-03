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
        [SerializeField] private float cooldown = 3f;
        [SerializeField] private float delay = 0.5f;
        private int bullet = 2;

        private float chrono;

        public WandGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Projectile> objPool, IEnemiesManager enemiesManager) : base(owner, updateSystem, objPool)
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

            Projectile projectile = _projectilePool.Get();
            projectile.transform.position = _owner.Transform.position;
            projectile.Rb.velocity = move;
        }

        async Task ShootAction()
        {
            for (int i = 0; i < bullet; i++)
            {
                Shoot();
                await Task.Delay(((int)(delay * 10)) * 100);
            }
        }

        public override void Update(float deltaTime)
        {
            chrono += deltaTime;
            if (chrono >= cooldown)
            {
                chrono = 0;
                ShootAction();
            }
        }
    }
}
