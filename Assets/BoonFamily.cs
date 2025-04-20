using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boon Family", menuName = "ScriptableObjects/PowerUp Family", order = 1)]
public class BoonFamily : ScriptableObject
{
    public string familyName;
    public List<Boon> Boons = new List<Boon>();
    BoonDictionary BoonDictionary = new BoonDictionary();

    public void SetDictionary() { BoonDictionary.SetDictionary(ref Boons); }

    public string SetUniqueName(Boon data)
    {
        data.uniqueName = familyName + "_" + data.boonName + "_" + data.tier;
        return data.uniqueName;
    }

    public Boon this[string key]
    {
        get => BoonDictionary[key];
        set => BoonDictionary[key] = value;
    }
}
