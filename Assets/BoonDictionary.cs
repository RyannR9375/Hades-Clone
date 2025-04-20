using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonDictionary
{
    public Dictionary<string, Boon> BoonLookup = new Dictionary<string, Boon>();

    public void SetDictionary(ref List<Boon> boon)
    {
        foreach (Boon x in boon)
        {
            BoonLookup.Add(x.uniqueName, x);
        }
    }

    public Boon this[string key]
    {
        get { if (BoonLookup.ContainsKey(key)) return BoonLookup[key]; else return Boon.Empty(); }
        set { if (BoonLookup.ContainsKey(key)) BoonLookup[key] = value; }
    }
}
 