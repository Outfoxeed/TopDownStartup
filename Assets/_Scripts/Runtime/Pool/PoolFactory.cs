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

        // TODO: Do generic stuff here (dirty RigidBody2D hardcoded)
        public ObjectPool<Projectile> CreatePool(GameObject prefab)
        {
            return new ObjectPool<Projectile>(() => CreatePooledItem(prefab), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, amountToPool, maxCapacity);
        }

        private Projectile CreatePooledItem(GameObject prefab)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);

            return obj.GetComponent<Projectile>();
        }

        private void OnTakeFromPool(Projectile rb)
        {
            rb.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(Projectile rb)
        {
            rb.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(Projectile rb)
        {
            GameObject.Destroy(rb.gameObject);
        }
    }
}
