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
    public class KnifeGun : GunBase
    {
        [SerializeField] private float speed = 10;
        [SerializeField] private float cooldown = 3f;
        [SerializeField] private float delay = 0.5f;
        private int bullet = 2;

        private float chrono;

        public KnifeGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Projectile> objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            Vector2 dir = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_owner.Transform.position).normalized;
            Vector2 move = dir * speed;

            Projectile projectile = _projectilePool.Get();
            projectile.Disabled.Clear();
            projectile.Disabled.AddListener(() => _projectilePool.Release(projectile));
            projectile.transform.position = _owner.Transform.position;
            projectile.transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir) - 45);
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
            if(chrono >= cooldown)
            {
                chrono = 0;
                _ = ShootAction();
            }
        }
    }
}
