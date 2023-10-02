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
        [SerializeField] private float r = 1f;
        [SerializeField] private float speed = 0.05f;
        private float deg = 0;

        [SerializeField] private float delay = 3f;
        [SerializeField] private float duration = 2f;
        private float chrono;
        private bool isOn;

        public BibleGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            //INIT
            deg = 0;
            //TODO : Activer Sprite

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
                //TODO : Desactiver sprite
            }

            if(isOn) 
            { 
                deg += speed;
                for(int i = 0; i < projectiles.Count; i++)
                {
                        projectiles[i].MovePosition(new Vector2(Mathf.Cos(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad), Mathf.Sin(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad)) * r + (Vector2)_owner.Transform.position);
                }   
            }

        }
    }
}
