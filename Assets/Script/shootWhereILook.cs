using System.Collections;
using System.Collections.Generic;
using Game.Runtime.Guns;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game
{
    /// <summary>
    /// NOT USED SCRIPT
    /// </summary>
    public class shootWhereILook : MonoBehaviour
    {
        [SerializeField] Transform firePoint;
        [SerializeField] GameObject bulletPrefab;


        [SerializeField]private float bulletforce = 20f;

        [SerializeField] private float timeBetweenBullet = 1f;

        ObjectPool<Projectile> bla;

        bool shoot = false;


        private void Start()
        {
            shoot = true;
            PoolFactory myObjectPool = new PoolFactory();
            bla = myObjectPool.CreatePool<Projectile>(bulletPrefab, 10);
            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            
            while (shoot == true)
            {
                GameObject bullet = bla.Get().gameObject;
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position;
                    bullet.SetActive(true);

                }                
               Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
                yield return new WaitForSeconds(timeBetweenBullet);


            }

        }
    }
}
