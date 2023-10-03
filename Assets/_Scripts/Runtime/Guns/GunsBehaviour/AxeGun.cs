using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class AxeGun : GunBase
    {
        private float speed = 10;
        private float cooldown = 3f;
        private float delay = 0.5f;
        private int bullet = 2;

        private float chrono;

        public AxeGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Rigidbody2D> objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            float radian = UnityEngine.Random.Range(Mathf.PI / 10, Mathf.PI / 10 * 9);
            Vector2 dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
            Vector2 move = dir * speed;

            Rigidbody2D projectile = _projectilePool.Get();
            projectile.transform.position = _owner.Transform.position;
            projectile.velocity = move;
        }

        async Task ShootAction()
        {
            for(int i = 0; i < bullet; i++)
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
