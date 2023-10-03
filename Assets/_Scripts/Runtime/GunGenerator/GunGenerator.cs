using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Guns;
using Game.Runtime.StartSystem;
using Game.Runtime.UnityCallbackSystems.StartSystem;
using Game.Runtime.UnityCallbackSystems.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Runtime.GunGenerator
{
    public class GunGenerator : IGunGenerator, IUpdate, IStart
    {
        [Inject] private GunGeneratorConfig _config;
        [Inject] private PlayerReference _playerRef;
        private Shooter _shooter;
        private IDisposable _updateDisposable;
        private IDisposable _startDisposable;

        private float _timeToGenerate;

        [Inject]
        public void Construct(IUpdateSystem updateSystem, IStartSystem startSystem)
        {
            _updateDisposable = updateSystem.Subscribe(this);
            _startDisposable = startSystem.Subscribe(this);
        }
        public void Deconstruct()
        {
            _updateDisposable?.Dispose();
            _updateDisposable = null;
            
            _startDisposable?.Dispose();
            _startDisposable = null;
        }

        public void GenerateGun()
        {
            Debug.Log("<color=green>Generate Gun</color>");
            
            int gunTypesCount = GunsTypeUtils.Count;
            if (_shooter.GunCount() >= gunTypesCount)
            {
                return;
            }

            GunsType[] possessedGuns = _shooter.GetGunTypes();
            List<int> possibilities = new (gunTypesCount);
            for (int i = 0; i < gunTypesCount; i++)
            {
                if (possessedGuns.Contains((GunsType)i))
                {
                    continue;
                }
                possibilities.Add(i);
            }

            if (possibilities.Count == 0)
            {
                return;
            }

            _shooter.AddGun((GunsType)possibilities[UnityEngine.Random.Range(0, possibilities.Count)]);
        }
        
        public void Start()
        {
            PlayerBrain playerBrain = _playerRef.Instance.GetComponentInChildren<PlayerBrain>();
            if (playerBrain == null)
            {
                throw new Exception("PlayerBrain MonoBehaviour not found in children of player");
            }

            _shooter = playerBrain.Shooter;
            _timeToGenerate = 0f;
        }

        public void Update(float deltaTime)
        {
            if (Time.time < _timeToGenerate)
            {
                return;
            }
            
            GenerateGun();
            _timeToGenerate = Time.time + _config.GunGenerationCooldown;
        }
    }
}