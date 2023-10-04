using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class PoolFactory : IPoolFactory
    {
        private int amountToPool = 10;

        public ObjectPool<T> CreatePool<T>(GameObject prefab, int maxCapacity) where T : Component
        {
            Transform poolItemsParent = new GameObject($"Pool ({prefab.name})").transform;
            return new ObjectPool<T>(() => CreatePooledItem<T>(prefab, poolItemsParent), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, amountToPool, maxCapacity);
        }

        private T CreatePooledItem<T>(GameObject prefab, Transform parent) where T : Component
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
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
