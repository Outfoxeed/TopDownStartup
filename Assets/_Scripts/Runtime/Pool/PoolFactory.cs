using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class PoolFactory
    {
        private int amountToPool = 10;
        private int maxCapacity = 20;

        public ObjectPool<Rigidbody2D> CreatePool(GameObject prefab)
        {
            return new ObjectPool<Rigidbody2D>(() => CreatePooledItem(prefab), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, amountToPool, maxCapacity);
        }

        private Rigidbody2D CreatePooledItem(GameObject prefab)
        {
            GameObject obj = GameObject.Instantiate(prefab);
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
            GameObject.Destroy(rb.gameObject);
        }
    }
}
