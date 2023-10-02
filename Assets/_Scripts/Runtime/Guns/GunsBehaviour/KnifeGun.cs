using Game.Runtime.UpdateSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class KnifeGun : GunBase
    {
        //[SerializeField] private GameObject TEMP_projectile;
        [SerializeField] private float speed;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public KnifeGun(IShooter owner, IUpdateSystem updateSystem) : base(owner, updateSystem)
        {
        }

        public override void Shoot()
        {
            //GameObject a = GameObject.Instantiate(TEMP_projectile);

            Vector2 dir = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)_owner.Transform.position).normalized;
            Vector2 move = dir * speed;

            //a.GetComponent<Rigidbody2D>().velocity = move;
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
