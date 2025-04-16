using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public AttackPattern AttackPattern { get => _attackPattern; set => _attackPattern = AttackPattern; }
    [SerializeField] private AttackPattern _attackPattern;
    //turn neg. health into RAGE? compensates in damage, burst of health/lifesteal
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        maxHealth = avatarStats.Health;
        currentHealth = avatarStats.Health;
        damage = avatarStats.Damage;
        speed = avatarStats.Speed;
    }

    private void Start()
    {
        
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
