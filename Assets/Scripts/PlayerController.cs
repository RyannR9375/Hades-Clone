using System;
using System.Collections;
using System.Collections.Generic;
using HadesClone;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, IAttackable
{
    static PlayerController _instance = null;
    public static PlayerController Instance { get { return _instance; } }

    [SerializeField] internal AvatarScriptable avatarStats;

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

    private StateMachine _stateMachine;
    private Animator _animator;
    private void Awake()
    {
        MakeSingleton();
        SetValues();
        SetDependencies();
        if(!_animator)TryGetComponent<Animator>(out _animator);

        _stateMachine = new StateMachine();
        var walkState = new WalkState(this, _animator);
        var attackState = new AttackState(this, _animator);
        var idleState = new IdleState(this, _animator);
        Any(idleState, new FuncPredicate(() => _move == Vector3.zero && !isAttacking));
        Any(walkState, new FuncPredicate(() => _move != Vector3.zero && !isAttacking));
        At(walkState, attackState, new FuncPredicate(() => isAttacking && _move != Vector3.zero));
        At(idleState, attackState, new FuncPredicate(() => isAttacking && _move == Vector3.zero));
        
        _stateMachine.SetState(walkState);
    }
    
    void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

    public IEnumerator HandleAttack() {
        yield return new WaitForSeconds(timeBtwAttacks);
        isAttacking = false;
    }

    private float timeBtwAttacks = 0.5f;
    private bool isAttacking;

    private void Start()
    {

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !isAttacking) {
            //Debug.Log("got keyboard input");
            isAttacking = true;
        }
        
        _stateMachine.Update();
    }

    private void FixedUpdate() {
        _stateMachine.FixedUpdate();
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
        if (!_rb) TryGetComponent<Rigidbody>(out _rb);
    }

    public Rigidbody _rb;
    public Vector3 _move;
    
    public void OnMove(InputAction.CallbackContext data)
    {
        _move = data.ReadValue<Vector2>();
        _move = new Vector3(_move.x, 0, _move.y);
        UnityEngine.Vector3 moveVector = Speed * transform.TransformDirection(_move) * Time.fixedDeltaTime * Time.timeScale;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVector), 0.15f);
        //transform.Translate(_move * Speed * Time.fixedDeltaTime, Space.World);
        
        _rb.linearVelocity = moveVector;
        
        //_rb.AddForce(moveVector, ForceMode.VelocityChange);
        
        //Vector3 newPos = Vector3.MoveTowards(transform.position, transform.position + moveVector, Speed);
        //_rb.MovePosition(newPos);
    }


    void MakeSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            TryGetComponent<PlayerController>(out _instance);
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
