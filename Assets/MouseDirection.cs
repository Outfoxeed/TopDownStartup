using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MouseDirection : MonoBehaviour
    {
        //[SerializeField ]Rigidbody2D _rb;

        Vector2 mousePos;

        public Camera cam;
        

        void Update()
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            Vector2 v2 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 lookDir = mousePos - v2;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            gameObject.transform.eulerAngles = new Vector3(0,0, angle);
        }
    }
}
