using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IAttackable
{
    [SerializeField] internal AvatarScriptable avatarStats;
    public AttackableBehavior AttackableBehavior { get { return _attackableBehavior; } set { _attackableBehavior = value; } }
    [SerializeField] internal AttackableBehavior _attackableBehavior;

    internal static Player _player;

    public float MaxHealth 
    {
        get { return Mathf.Clamp(_maxHealth, 0, _maxHealth); }
        set { _maxHealth = value; Mathf.Clamp(_maxHealth, 0, _maxHealth >= value ? _maxHealth : value); }
    }
    [SerializeReference] internal float _maxHealth;

    public float CurrentHealth
    {
        get { return Mathf.Clamp(_currentHealth, 0, _currentHealth); }
        set { _currentHealth = value; Mathf.Clamp(_currentHealth, 0, _currentHealth >= value ? _currentHealth : value); }
    }
    [SerializeReference] internal float _currentHealth;

    public float Damage
    {
        get { return Mathf.Clamp(_damage, 0, _damage); }
        set { _damage = value; Mathf.Clamp(_damage, 0, _damage >= value ? _damage : value); }
    }
    [SerializeReference] internal float _damage;

    public float Speed
    {
        get { return Mathf.Clamp(_speed, 0, _speed); }
        set { _speed = value; Mathf.Clamp(_speed, 0, _speed >= value ? _speed : value); }
    }
    [SerializeReference] internal float _speed;

    internal void Start()
    {
        if (_player == null) _player = Player.Instance;
        MaxHealth = avatarStats.Health;
        CurrentHealth = avatarStats.Health;
        Damage = avatarStats.Damage;
        Speed = avatarStats.Speed;
    }
}
