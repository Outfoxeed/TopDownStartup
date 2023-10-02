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

        public override void Shoot()
        {
            //GameObject a = GameObject.Instantiate(TEMP_prefab);

            Vector2 dir = new Vector2(Mathf.Cos(UnityEngine.Random.Range(0, Mathf.PI)), Mathf.Sin(UnityEngine.Random.Range(0, Mathf.PI)) * power);
            //a.transform.position = Vector3.zero;
            //a.GetComponent<Rigidbody2D>().velocity += dir;
        }

        public override void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
