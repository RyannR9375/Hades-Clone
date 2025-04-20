using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boon Family", menuName = "ScriptableObjects/PowerUp Family", order = 1)]
public class BoonFamily : ScriptableObject
{
    public string familyName;
    public List<Boon> Powerups = new List<Boon>();
    BoonDictionary PowerupDictionary = new BoonDictionary();

    public void SetDictionary() { PowerupDictionary.SetDictionary(ref Powerups); }

    public string SetUniqueName(Boon data)
    {
        data.uniqueName = familyName + "_" + data.boonName + "_" + data.tier;
        return data.uniqueName;
    }

    public Boon this[string key]
    {
        get => PowerupDictionary[key];
        set => PowerupDictionary[key] = value;
    }
}
