using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoonCategory
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
    public BoonCategory  boonCategory;

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

    public delegate void GetBoonName<out Boon>();
    public delegate Boon GetBoon(string name);

    public void Main() {
        //THE LAST PARAMETER IS ALWAYS THE 'OUT' VALUE (RETURN VALUE)
        Func<Boon> method = () => BoonFamilies[0].Boons[0]; //JUST OUT (RETURNS A BOON)
        string result = method().boonName;

        Debug.Log($"Result: {result}");

        Func<string, string> method2 = delegate(string s) //IN AND OUT (RETURNS THE PASSED IN STRING)
        {
            return s;
        };

        Func<Boon, string> method3 = delegate (Boon b) //IN AND OUT (RETURN A BOON NAME)
        {
            return b.uniqueName;
        };

        Func<Boon, string, string> method4 = delegate(Boon b, string s) //IN AND OUT (RETURN A BOON NAME)
        {
            return b.uniqueName + s;
        };
        
        Action<Boon> method5 = delegate(Boon b) //IN (DOES NOT RETURN ANYTHING, JUST EXECUTES THE FUNCTION INSIDE THE {}
        {
            Debug.Log(b.boonName);
        };

        //Func<Boon, string, Boon> method6 = GetBoon(s) //IN AND OUT (RETURN A BOON NAME)
        //{
        //};
    }
}
