using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class bulletInFront : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            gameObject.SetActive(false);
        }
    }
}
