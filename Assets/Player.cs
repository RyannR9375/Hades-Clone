using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    [SerializeField] Avatar avatarStats;
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float speed;
    public string PlayerName { get => avatarStats.AvatarName; set => avatarStats.AvatarName = PlayerName; }
    public AttackPattern AttackPattern { get => _attackPattern; set {; } } //NO SET SINCE MIGHT CHANGE DURING RUNTIME
    [SerializeField] private AttackPattern _attackPattern;
    //turn neg. health into RAGE? compensates in damage, burst of health/lifesteal
    private void Awake()
    {
        //SINGLETON
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        //SET STATS
        maxHealth = avatarStats.Health;
        currentHealth = avatarStats.Health;
        damage = avatarStats.Damage;
        speed = avatarStats.Speed;

        //DEPENDENCIES
        if (!_rb) TryGetComponent<Rigidbody2D>(out _rb);
    }

    private void Start()
    {
        
    }

    Rigidbody2D _rb;
    Vector2 _movement;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnMove(InputValue data)
    {
        _movement = data.Get<Vector2>();
        _movement = new UnityEngine.Vector2(_movement.x, _movement.y).normalized;

        UnityEngine.Vector3 moveVector = speed * Time.fixedDeltaTime * Time.timeScale * transform.TransformDirection(_movement);
        _rb.linearVelocity = new UnityEngine.Vector2(moveVector.x, moveVector.y);
    }

    public void SetHealth(float data)
    {
        if (data < 0) data = 0;
        currentHealth = data;
    }

    public void SetDamage(float data)
    {
        if (data < 0) data = 0;
        damage = data;
    }
    public void SetSpeed(float data)
    {
        if (data < 0) data = 0;
        speed = data;
    }
}
