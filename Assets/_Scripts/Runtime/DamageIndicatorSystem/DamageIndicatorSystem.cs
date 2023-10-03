using System;
using System.Collections.Generic;
using Game.Runtime.Enemies;
using Game.Runtime.UnityCallbackSystems.StartSystem;
using ScriptableObjectArchitecture;
using UnityEngine.Pool;
using Zenject;

namespace Game.Runtime.DamageIndicatorSystem
{
    public class DamageIndicatorSystem : IDamageIndicatorSystem, IStart
    {
        [Inject] private DamageIndicatorSystemConfig _config;
        [Inject(Id = "EntityDamagedGameEvent")] private EntityDamagedGameEvent _entityDamagedGameEvent;

        private IDisposable _startSubscription;
        private IObjectPool<FloatingTextHandler> _pool;
        private List<FloatingTextHandler> _activeFloatingTexts = new();

        [Inject]
        private void Construct(IStartSystem startSystem, IPoolFactory poolFactory)
        {
            _startSubscription = startSystem.Subscribe(this);
            _pool = poolFactory.CreatePool<FloatingTextHandler>(_config.Prefab.gameObject);
        }
        public void Deconstruct()
        {
            _entityDamagedGameEvent.RemoveListener(OnEntityDamaged);
        }

        public void Start()
        {
            _entityDamagedGameEvent.AddListener(OnEntityDamaged);
            
            _startSubscription?.Dispose();
            _startSubscription = null;
        }
        
        private void OnEntityDamaged(EntityDamaged entityDamagedInfo)
        {
            GetFloatingTextInstance().SetPosition(entityDamagedInfo.Entity.transform.position).SetText(entityDamagedInfo.DamageTaken.ToString());
        }

        private FloatingTextHandler GetFloatingTextInstance()
        {
            FloatingTextHandler instance = _pool.Get();
            instance.gameObject.SetActive(true);
            instance.Disabled.Clear();
            instance.Disabled.AddListener(() =>
            {
                _pool.Release(instance);
                _activeFloatingTexts.Remove(instance);
            });
            
            _activeFloatingTexts.Add(instance);
            return instance;
        }
    }
}