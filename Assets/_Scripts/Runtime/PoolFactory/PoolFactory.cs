using Game.Runtime.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class PoolFactory : IPoolFactory
    {
        private int amountToPool = 10;
        private int maxCapacity = 20;

        public ObjectPool<T> CreatePool<T>(GameObject prefab) where T : Component
        {
            return new ObjectPool<T>(() => CreatePooledItem<T>(prefab), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, amountToPool, maxCapacity);
        }

        private T CreatePooledItem<T>(GameObject prefab) where T : Component
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);

            return obj.GetComponent<T>();
        }

        private void OnTakeFromPool<T>(T poolItem) where T : Component
        {
        }

        private void OnReturnedToPool<T>(T poolItem) where T : Component
        {
            poolItem.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject<T>(T poolItem) where T : Component
        {
            GameObject.Destroy(poolItem.gameObject);
        }
    }
}
