using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonDictionary : MonoBehaviour
{
    public readonly static Dictionary<string, Action> BoonActions = new Dictionary<string, Action>()
    {
        { "Jacky_Stink Bombs_Tier1", () => Jacky_StinkBombs() }, //J
        // Add more actions as needed
    };

    static void Jacky_StinkBombs() //J
    {
        Debug.Log("Jacky Stink Bombs activated!");

    }

    public Action this[string key]
    {
        get
        {
            if (BoonActions.TryGetValue(key, out Action action))
            {
                return action;
            }
            else
            {
                Debug.LogError($"Action with key {key} not found in BoonDictionary.");
                return null;
            }
        }
    }

}
//pass in a uniqueID and receive an Action
 