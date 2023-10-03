using System;
using System.Collections;
using System.Collections.Generic;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class BibleGun : GunBase
    {
        private List<Projectile> projectiles = new List<Projectile>();
        [SerializeField] private float r = 2f;
        [SerializeField] private float speed = 2f;
        private int bullet = 2;
        private float deg = 0;

        [SerializeField] private float delay = 3f;
        [SerializeField] private float duration = 2f;
        private float chrono;
        private bool isOn;

        public BibleGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Projectile> objPool) : base(owner, updateSystem, objPool)
        {
            for (int i = 0; i < bullet; i++)
                projectiles.Add(_projectilePool.Get());
        }

        public override void Shoot()
        {
            deg = 0;

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Rb.position = new Vector2(Mathf.Cos(2 * Mathf.PI / projectiles.Count * i), Mathf.Sin(2 * Mathf.PI / projectiles.Count * i)) * r + (Vector2)_owner.Transform.position;
            }

            isOn = true;
        }

        public override void Update(float deltaTime)
        {
            chrono += deltaTime;

            if (!isOn && chrono >= delay)
            {
                chrono = 0f;
                isOn = true;

                for (int i = 0; i < projectiles.Count; i++)
                    projectiles[i].gameObject.SetActive(true);
                
                Shoot();
            }
            else if(isOn && chrono >= duration)
            {
                chrono = 0f;
                isOn = false;

                for (int i = 0; i < projectiles.Count; i++)
                    projectiles[i].gameObject.SetActive(false);
            }

            if(isOn) 
            { 
                deg += speed / 100;
                for(int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Rb.MovePosition(new Vector2(Mathf.Cos(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad), Mathf.Sin(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad)) * r + (Vector2)_owner.Transform.position);
                }   
            }

        }
    }
}
