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
        [SerializeField] private float power = 2;
        [SerializeField] private float delay = 3f;
        private float chrono;

        public AxeGun(IShooter owner, IUpdateSystem updateSystem) : base(owner, updateSystem)
        {
        }

        public override void Shoot()
        {
            //GameObject a = GameObject.Instantiate(TEMP_prefab);

            Vector2 dir = new Vector2(Mathf.Cos(UnityEngine.Random.Range(0, Mathf.PI)), Mathf.Sin(UnityEngine.Random.Range(0, Mathf.PI)) * power);
            //a.transform.position = _owner.Transform.position;
            //a.GetComponent<Rigidbody2D>().velocity += dir;
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
