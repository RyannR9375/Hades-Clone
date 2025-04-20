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
    public PowerupFor  powerup;

    public int tier;
    public  string powerupName;
    private string uniqueName;


    public float change;
    public float totalTime;
}

public struct PowerupFamily
{

}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUp", order = 2)]
public class PowerupScriptable : ScriptableObject
{
    public List<Powerup> powerups = new List<Powerup>();

    //public List<string> SetUniqueNames()
    //{ 
    //    //List<string> UniqueNames = new List<string>();
    //    //foreach(Powerup x in powerups){ 
    //    //    x.SetUniqueName();
    //    //    UniqueNames.Add(x.GetUniqueName());
    //    //}
    //    //return UniqueNames;
    //}
}
