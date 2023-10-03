using Game.Runtime.UpdateSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class AxeGun : GunBase
    {
        [SerializeField] private float speed = 10;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public AxeGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Rigidbody2D> objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            float radian = UnityEngine.Random.Range(0, Mathf.PI);
            Vector2 dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
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
