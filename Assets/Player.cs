using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IAttackable
{
    static Player _instance = null;
    public static Player Instance { get { return _instance; } }

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
    public string PlayerName { get => avatarStats.AvatarName; set => avatarStats.AvatarName = PlayerName; }
    public AttackPattern AttackPattern { get => _attackPattern; set {; } } //NO SET SINCE MIGHT CHANGE DURING RUNTIME
    [SerializeField] private AttackPattern _attackPattern;

    //turn neg. health into RAGE? compensates in damage, burst of health/lifesteal
    private void Awake()
    {
        MakeSingleton();
        SetValues();
        SetDependencies();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void SetValues()
    {
        MaxHealth = avatarStats.Health;
        CurrentHealth = avatarStats.Health;
        Damage = avatarStats.Damage;
        Speed = avatarStats.Speed;
    }

    void SetDependencies()
    {
        if (!_rb) TryGetComponent<Rigidbody2D>(out _rb);
    }

    private void FixedUpdate()
    {
        
    }

    Rigidbody2D _rb;
    Vector2 _movement;
    private void OnMove(InputValue data)
    {
        _movement = data.Get<Vector2>();
        _movement = new UnityEngine.Vector2(_movement.x, _movement.y).normalized;

        UnityEngine.Vector3 moveVector = Speed * Time.fixedDeltaTime * Time.timeScale * transform.TransformDirection(_movement);
        _rb.linearVelocity = new UnityEngine.Vector2(moveVector.x, moveVector.y);
    }

    void MakeSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            TryGetComponent<Player>(out _instance);
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }

    public ref float ReturnReferenceHealth() { return ref _currentHealth; }
    public ref float ReturnReferenceSpeed() { return ref _speed; }
    public ref float ReturnReferenceDamage() { return ref _damage; }
    public ref float ReturnReferenceMaxHealth() { return ref _maxHealth; }
}
