using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Bson;
using UnityEngine;

namespace Game
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager instance;
        [SerializeField] PoolData pool;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        public PoolData Get(GameObject prefab)
        {
            PoolData myObjectPool = PoolData.Instantiate(pool); 
            myObjectPool.SetPrefab(prefab);
            return myObjectPool;
        }
    }

}
