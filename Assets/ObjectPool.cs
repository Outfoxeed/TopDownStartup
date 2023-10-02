using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObjectPool : MonoBehaviour
    {

        private List<GameObject> poolObjects = new List<GameObject>();
        private int amountToPool = 20;
        [SerializeField] private GameObject bulletPrefab;

        
        public void SetPrefab(GameObject prefab)
        {
            bulletPrefab = prefab;
        }
        private void Awake()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                poolObjects.Add(obj);
            }

        }
        

        public GameObject GetPoolObject()
        {
            for(int i = 0; i < poolObjects.Count; i++)
            {
                if (!poolObjects[i].activeInHierarchy)
                {
                    return poolObjects[i];  
                }
            }

            return null;
        }
    }
}
