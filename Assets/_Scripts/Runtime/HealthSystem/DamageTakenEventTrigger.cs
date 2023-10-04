using Game.Runtime.Enemies;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Game.Runtime.HealthSystem
{
    public class DamageTakenEventTrigger : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private EntityDamagedGameEvent _event;
        private void OnEnable()
        {
            _entity.Health.Damaged.AddListener(OnEntityDamaged);
        }
        
        private void OnDisable()
        {
            _entity.Health.Damaged.RemoveListener(OnEntityDamaged);
        }
        
        private void OnEntityDamaged(int damageAmount)
        {
            _event.Raise(new EntityDamaged(_entity, _entity.Health.IsDead, damageAmount));
        }
    }
}