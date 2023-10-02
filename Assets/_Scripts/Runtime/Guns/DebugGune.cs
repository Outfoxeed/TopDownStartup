using Game.Runtime.UpdateSystem;
using UnityEngine;

namespace Game.Runtime.Guns
{
    public class DebugGune : GunBase
    {
        public DebugGune(IShooter owner, IUpdateSystem updateSystem) : base(owner, updateSystem)
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