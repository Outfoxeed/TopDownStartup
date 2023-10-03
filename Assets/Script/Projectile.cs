using UnityEngine;
using Game.Runtime.MusketeerEvents;

namespace Game.Runtime.Guns
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        [SerializeField] private PlayerReference _player;

        public int Damage { get => damage; set => damage = value; }

        private MusketeerEvent hitEvent;
        public MusketeerEvent HitEvent { get => hitEvent; set => hitEvent = value; }

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
            
            health.TakeDamage(damage);

            hitEvent.Invoke();
        }
    }
}
