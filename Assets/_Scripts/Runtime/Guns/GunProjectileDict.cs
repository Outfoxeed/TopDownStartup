using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Game.Runtime.Guns
{
    [CreateAssetMenu]
    [Serializable]
    public class GunProjectileDict : ScriptableObject
    {
        [SerializedDictionary("Gun Type", "Sprite"), SerializeField]
        private SerializedDictionary<GunsType, GameObject> projectilePrefabDict = new SerializedDictionary<GunsType, GameObject>();
        public SerializedDictionary<GunsType, GameObject> ProjectilePrefabDict => projectilePrefabDict;
    }
}
