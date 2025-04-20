using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoonFor
{
    Damage,
    Health,
    Speed
}

public enum BoonType
{
    Buff,
    Debuff
}

public enum BoonTime
{
    Instant,
    Over_Time,
    Curve
}

[System.Serializable, SerializeField]
public struct Boon
{
    public BoonType type;
    public BoonTime time;
    public BoonFor  powerup;

    public string boonName;
    public string description;
    [HideInInspector] public string uniqueName;
    [HideInInspector] public int tier;

    public float change;
    public float totalTime;

    static public Boon Empty()
    {
        Boon empty = new Boon();
        empty.boonName = "ERROR.";
        return empty;
    }

    string ConvertDescription()
    {
        string result = description;
        result = result.Replace("{change}", change.ToString());
        result = result.Replace("{time}", totalTime.ToString());
        return result;
    }
}

[CreateAssetMenu(fileName = "Boon Holder", menuName = "ScriptableObjects/Boon Holder", order = 2)]
public class BoonHolder : ScriptableObject
{
    public List<BoonFamily> BoonFamilies = new List<BoonFamily>();
}
