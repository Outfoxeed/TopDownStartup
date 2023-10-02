using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Guns;
using Game.Runtime.Guns.Factory;
using UnityEngine;
using Zenject;

namespace Game.Runtime
{
    public class Shooter : IGunInventory, IShooter
    {
        public Transform Transform { get; }
        private Dictionary<GunsType, IGun> _guns = new();
        private IGunFactory _gunFactory;

        public Shooter(Transform ownerTransform, IGunFactory gunFactory)
        {
            Transform = ownerTransform;
            _gunFactory = gunFactory;
        }

        public GunsType[] GetGunTypes() => _guns.Keys.ToArray();
        public bool HasGun(GunsType gunsType) => _guns.ContainsKey(gunsType);

        public bool AddGun(GunsType gunType)
        {
            if (HasGun(gunType))
            {
                return false;
            }
            
            _guns.Add(gunType, _gunFactory.Create(this, gunType));
            return true;
        }

        public int GunCount() => _guns.Count;
    }
}