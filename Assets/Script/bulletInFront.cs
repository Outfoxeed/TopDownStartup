using UnityEngine;

namespace Game
{

    public class bulletInFront : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        private  IHealth _health;

        [SerializeField] private PlayerReference _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth health = collision.GetComponent<IHealth>();
            if(health != null)
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
