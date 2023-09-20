using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MouseDirection : MonoBehaviour
    {
        [SerializeField ]Rigidbody2D _rb;

        Vector2 mousePos;

        public Camera cam;
        

        void Update()
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            
            Vector2 lookDir = mousePos - _rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }
    }
}
