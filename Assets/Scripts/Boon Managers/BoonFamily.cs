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

        //string debug = "";
        for(int i = 0; i < count; ++i)
        {
            (Boon,int) returnBoon = ReturnRandomBoon();
            while (usedIdxs.Contains(returnBoon.Item2)){
                returnBoon = ReturnRandomBoon();
            }
            boonsToReturn[i] = returnBoon.Item1;
            usedIdxs.Add(returnBoon.Item2);
            //debug += $"{returnBoon.Item1.BoonName}, ";
        }
        //Debug.Log(debug);
        return boonsToReturn;
    }

    public (Boon,int) ReturnRandomBoon()
    {
        int idx = UnityEngine.Random.Range(0, Boons.Count);
        while (BoonManager.Instance.ActiveBoons.ContainsValue(Boons[idx]))
        {
            int newIdx = UnityEngine.Random.Range(0, Boons.Count);
            idx = newIdx;
        }
        return (Boons[idx], idx);
    }
}
