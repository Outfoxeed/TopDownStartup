using System;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Game.Runtime.Enemies;
using Game.Runtime.Entities;
using Game.Runtime.HealthSystem;
using Game.Runtime.MusketeerEvents;
using UnityEngine;

public class AIBrain : MonoBehaviour, IEnemy
{
    [SerializeField, BoxGroup("Special Dependency")] PlayerReference _playerEntity;

    [SerializeField, BoxGroup("Dependencies")] Entity _root;
    [SerializeField, BoxGroup("Dependencies")] EntityMovement _movement;
    [SerializeField, BoxGroup("Dependencies")] EntityAttack _attack;

    [SerializeField, BoxGroup("Conf")] float _distanceDetection;
    [SerializeField, BoxGroup("Conf")] float _stopDistance;
    
    [field: Header("Events"), SerializeField]
    public MusketeerEvent Disabled { get; private set; }

    bool IsPlayerNear => Vector3.Distance(_root.transform.position, _playerEntity.Instance.transform.position) < _distanceDetection;
    bool IsPlayerTooNear => Vector3.Distance(_root.transform.position, _playerEntity.Instance.transform.position) < _stopDistance;

    [SerializeField] private float cooldown = 0.5f;
    private float chrono;

    #region EDITOR
#if UNITY_EDITOR
    void Reset()
    {
        _playerEntity = null;
        _root = GetComponentInParent<Entity>();
        _movement = _root.GetComponentInChildren<EntityMovement>();
        _distanceDetection = 3f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_root.transform.position, _distanceDetection);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_root.transform.position, _stopDistance);
    }
#endif
    #endregion

    private void Update()
    {
        // Attack
        chrono += Time.deltaTime;
        
        if(IsPlayerTooNear)
        {
            _movement.Move(Vector2.zero);

            if(chrono > cooldown)
            {
                chrono = 0;
                _attack.LaunchAttack();
            }
        }
        // Move To Player
        else if (IsPlayerNear)
        {
            _movement.MoveToward(_playerEntity.Instance.transform);
        }
        // Stay idle
        else
        {
            _movement.Move(Vector2.zero);
        }
    }

    private void OnDisable()
    {
        Disabled.Invoke();
    }


    [field: SerializeField]
    public EntityGfx Gfx { get; private set; }
    private EnemyData _enemyData;
    
    public IHealthComponent Health => _root.Health;
    public Transform Transform => transform;
    
    public void SetData(EnemyData enemyData)
    {
        _enemyData = enemyData;
        Health.Reset(_enemyData.MaxHealth);
        _movement.SetSpeed(enemyData.MoveSpeed);
        Gfx.SetSprite(enemyData.Sprite);
    }
}
