using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupFor
{
    Damage,
    Health,
    Speed
}

public enum PowerupType
{
    Buff,
    Debuff
}

public enum PowerupTime
{
    Instant,
    Over_Time,
    Curve
}

[System.Serializable, SerializeField]
public struct Powerup
{
    public PowerupType type;
    public PowerupTime time;
    public PowerupFor powerup;

    public float change;
    public float totalTime;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUp", order = 1)]
public class PowerupScriptable : ScriptableObject
{

    public List<Powerup> powerups = new List<Powerup>();
    //DEBUG
}
