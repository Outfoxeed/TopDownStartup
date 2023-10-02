using Game.Runtime.UpdateSystem;
using UnityEngine;

namespace Game.Runtime.Guns
{
    public class DebugGune : GunBase
    {
        public DebugGune(IShooter owner, IUpdateSystem updateSystem, PoolData objPool) : base(owner, updateSystem, objPool)
        {
        }
        
        public override void Shoot()
        {
            Debug.Log("PEW SHOOT");
        }

        public override void Update(float deltaTime)
        {
            Debug.Log("PEW UDPTAE");
        }

    }
}