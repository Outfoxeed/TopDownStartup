using Game.Runtime.UpdateSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class BibleGun : GunBase
    {
        private List<Rigidbody2D> projectiles = new List<Rigidbody2D>();
        [SerializeField] private float r = 2f;
        [SerializeField] private float speed = 2f;
        private float deg = 0;

        [SerializeField] private float delay = 3f;
        [SerializeField] private float duration = 2f;
        private float chrono;
        private bool isOn;

        public BibleGun(IShooter owner, IUpdateSystem updateSystem, PoolData objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            //TEMP
            for (int i = 0; i < 4; i++)
                projectiles.Add(_projectilePool.Pool.Get());

            deg = 0;

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].position = new Vector2(Mathf.Cos(2 * Mathf.PI / projectiles.Count * i), Mathf.Sin(2 * Mathf.PI / projectiles.Count * i)) * r + (Vector2)_owner.Transform.position;
            }

            isOn = true;
        }

        public override void Update(float deltaTime)
        {
            chrono += deltaTime;

            if (!isOn && chrono >= delay)
            {
                chrono = 0f;
                Shoot();
                isOn = true;
            }
            else if(isOn && chrono >= duration)
            {
                chrono = 0f;
                isOn = false;
                
                for (int i = 0;i < projectiles.Count; i++)
                    _projectilePool.Pool.Release(projectiles[i]);

                projectiles.Clear();
            }

            if(isOn) 
            { 
                deg += speed / 100;
                for(int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].MovePosition(new Vector2(Mathf.Cos(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad), Mathf.Sin(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad)) * r + (Vector2)_owner.Transform.position);
                }   
            }

        }
    }
}
