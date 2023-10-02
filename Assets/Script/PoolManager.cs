using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Bson;
using UnityEngine;

namespace Game
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager instance;
        [SerializeField] ObjectPool pool;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        public ObjectPool Get(GameObject prefab)
        {
            ObjectPool myObjectPool = ObjectPool.Instantiate(pool); 
            myObjectPool.SetPrefab(prefab);
            return myObjectPool;
        }
    }

}
