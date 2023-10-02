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

        public BibleGun(IShooter owner, IUpdateSystem updateSystem) : base(owner, updateSystem)
        {
        }

        public override void Shoot()
        {   
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].position = new Vector2(Mathf.Cos(2 * Mathf.PI / projectiles.Count * i), Mathf.Sin(2 * Mathf.PI / projectiles.Count * i)) * r + (Vector2)_owner.Transform.position;
            }
        }

        public override void Update(float deltaTime)
        {
            deg += speed;
            for(int i = 0; i < projectiles.Count; i++)
            {
                    projectiles[i].MovePosition(new Vector2(Mathf.Cos(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad), Mathf.Sin(deg + 360 / projectiles.Count * i * Mathf.Deg2Rad)) * r + (Vector2)_owner.Transform.position);
            }   
        }
    }
}
