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

    public Boon[] ReturnRandomBoons(int count)
    {
        if(count >= Boons.Count) { count = Boons.Count-1; }

        Boon[] boonsToReturn = new Boon[count];
        List<int> usedIdxs = new();

        for (int i = 0; i < count; ++i) 
        {
            //SMALL ISSUE OF NOT ALWAYS RETURNING UNIQUE BOONS !!!!!!!!!!!!
            int idx = UnityEngine.Random.Range(0, Boons.Count);
            while (usedIdxs.Contains(idx)){
                idx = UnityEngine.Random.Range(0, Boons.Count);
            }

            boonsToReturn[i] = Boons[idx];
            usedIdxs.Add(idx);
            //Debug.Log($"Returning Boon: {Boons[i]}");
        }
        
        return boonsToReturn;
    }
}
