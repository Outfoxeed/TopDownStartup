using Game.Runtime.UpdateSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.Guns
{
    [Serializable]
    public class AxeGun : GunBase
    {
        //[SerializeField] private GameObject TEMP_prefab;
        [SerializeField] private float speed = 2;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public AxeGun(IShooter owner, IUpdateSystem updateSystem, ObjectPool objPool) : base(owner, updateSystem, objPool)
        {
        }

        public override void Shoot()
        {
            //GameObject a = GameObject.Instantiate(TEMP_prefab);

            float radian = UnityEngine.Random.Range(0, Mathf.PI);
            Vector2 dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
            Vector2 move = dir * speed;

            //a.transform.position = _owner.Transform.position;
            //a.GetComponent<Rigidbody2D>().velocity += move;
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
