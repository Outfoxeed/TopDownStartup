using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Game.Runtime.MusketeerEvents;
using UnityEngine;
using Game.Runtime.MusketeerEvents;
using System;
using UnityEngine.Pool;
using Zenject;

namespace Game.Runtime.Guns
{
    public class Projectile : MonoBehaviour
    {
        [field: SerializeField] public MusketeerEvent Disabled { get; private set; }
        public int Damage { get => damage; set => damage = value; }
        [SerializeField] private int damage = 1;
        
        public Rigidbody2D Rb => rb;
        [SerializeField]private Rigidbody2D rb;
        
        [SerializeField] private PlayerReference _player;

        private float _lifeDuration = 5f;
        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _ = DisableAfterLifeDuration();
        }
        
        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
            Disabled.Invoke();
        }

        private async Task DisableAfterLifeDuration()
        {
            await Task.Delay((int)(_lifeDuration * 1000f), _cancellationTokenSource.Token);
            gameObject.SetActive(false);
        }

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
        }
        
        public Projectile SetLifeDuration(float lifeDuration)
        {
            _cancellationTokenSource.Cancel();
            _lifeDuration = lifeDuration;
            _ = DisableAfterLifeDuration();
            return this;
        }
    }
}
