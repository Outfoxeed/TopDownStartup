using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Runtime.Guns
{
    public class DebugGune : GunBase
    {
        public DebugGune(IShooter owner, IUpdateSystem updateSystem, ObjectPool<Rigidbody2D> objPool) : base(owner, updateSystem, objPool)
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