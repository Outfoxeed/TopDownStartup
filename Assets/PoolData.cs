using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class PoolData : MonoBehaviour
    {
        private ObjectPool<Rigidbody2D> m_Pool;
        private GameObject bulletPrefab;
        private int amountToPool = 10;
        private int maxCapacity = 20;
        public ObjectPool<Rigidbody2D> Pool => m_Pool;

        public void SetPrefab(GameObject prefab)
        {
            bulletPrefab = prefab;

            m_Pool = new ObjectPool<Rigidbody2D>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, amountToPool, maxCapacity);
        }

        private Rigidbody2D CreatePooledItem()
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);

            return obj.GetComponent<Rigidbody2D>();
        }

        private void OnTakeFromPool(Rigidbody2D rb)
        {
            rb.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(Rigidbody2D rb)
        {
            rb.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(Rigidbody2D rb)
        {
            Destroy(rb.gameObject);
        }
    }
}
