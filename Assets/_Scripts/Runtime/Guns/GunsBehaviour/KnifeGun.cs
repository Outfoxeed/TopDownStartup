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
    public class KnifeGun : GunBase
    {
        [SerializeField] private float speed = 5;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public KnifeGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Rigidbody2D> objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            Rigidbody2D projectile = _projectilePool.Get();

            Vector2 dir = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_owner.Transform.position).normalized;
            Vector2 move = dir * speed;

            projectile.transform.position = _owner.Transform.position;
            projectile.velocity += move;

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
            if(chrono >= delay)
            {
                chrono = 0;
                Shoot();
            }
        }
    }
}
