using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class shootWhereILook : MonoBehaviour
    {
        [SerializeField] Transform firePoint;
        [SerializeField] GameObject bulletPrefab;


        [SerializeField]private float bulletforce = 20f;

        [SerializeField] private float timeBetweenBullet = 1f;

        bool shoot = false;


        private void Start()
        {
            shoot = true;

            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            PoolData myObjectPool = PoolManager.instance.Get(bulletPrefab);
            while (shoot == true)
            {
                GameObject bullet = myObjectPool.Pool.Get().gameObject;
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
