using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Guns;
using Game.Runtime.UpdateSystem;
using UnityEngine;
using Zenject;

namespace Game.Runtime.GunGenerator
{
    public class GunGenerator : IGunGenerator, IUpdated
    {
        [Inject] private GunGeneratorConfig _config;
        private Shooter _shooter;
        private IDisposable _updateDisposable;

        private float _timeToGenerate;
        
        [Inject]
        public void Construct(IUpdateSystem updateSystem, PlayerReference playerReference)
        {
            PlayerBrain playerBrain = playerReference.Instance.GetComponentInChildren<PlayerBrain>();
            if (playerBrain == null)
            {
                throw new Exception("PlayerBrain MonoBehaviour not found in children of player");
            }

            _shooter = playerBrain.Shooter;
            _updateDisposable = updateSystem.SubsribeToUpdate(this);

            _timeToGenerate = 0f;
        }
        public void Deconstruct()
        {
            _updateDisposable?.Dispose();
            _updateDisposable = null;
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