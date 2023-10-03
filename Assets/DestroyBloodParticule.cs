using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DestroyBloodParticule : MonoBehaviour
    {
        
        void Update()
        {
            Destroy(gameObject, 3f);
        }
    }
}
