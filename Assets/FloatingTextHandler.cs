using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FloatingTextHandler : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject , 1f);
            transform.localPosition += new Vector3(0, 0.5f, 0);
        }
    }
}
