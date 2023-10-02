using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Test : MonoBehaviour
    {
        public PlayerBrain pb;

        private void Awake()
        {
            pb.Shooter.AddGun(Runtime.Guns.GunsType.Bible);
        }
    }
}
