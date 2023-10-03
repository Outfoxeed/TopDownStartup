using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        [SerializeField] private PlayerReference _player;

        public int Damage { get => damage; set => damage = value; }

        [SerializeField]private Rigidbody2D rb;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth health = collision.GetComponent<IHealth>();
            if (health != null)
            {
                if (((IHealth)_player.Instance.Health) != health)
                {
                    health.TakeDamage(damage);
                    gameObject.SetActive(false);

                }

            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            gameObject.SetActive(false);
        }
    }
}
