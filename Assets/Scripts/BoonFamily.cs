using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "New Boon Family", menuName = "ScriptableObjects/PowerUp Family", order = 1)]
public class BoonFamily : ScriptableObject
{
    public string familyName;
    [SerializeReference] public List<Boon> Boons = new List<Boon>();

    public string SetUniqueName(Boon data)
    {
        data.UniqueName = $"{familyName}_{data.BoonName}_Tier{data.Tier}";
        return data.UniqueName;
    }

    public void SetUniqueNames()
    {
        foreach (Boon boon in Boons) { SetUniqueName(boon); }
    }
}
