using UnityEngine;

namespace Game
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        [SerializeField] private PlayerReference _player;

        public int Damage { get => damage; set => damage = value; }

        public Rigidbody2D Rb => rb;
        [SerializeField]private Rigidbody2D rb;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.attachedRigidbody.gameObject == _player.Instance.gameObject)
            {
                return;
            }

            if (!collision.TryGetComponent(out IHealth health))
            {
                return;
            }
            
            // if (!collision.TryGetComponent(out IHealth health))
            // {
            //     if (!collision.TryGetComponent(out IHealthProxy healthProxy))
            //     {
            //         // No health or health proxy not found
            //         return;
            //     }
            //     health = healthProxy.Health;
            // }
            //
            // // Health is not null
            // if (_player.Instance.Health == health)
            // {
            //     return;
            // }
            
            health.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
