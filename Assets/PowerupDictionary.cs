using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUpDictionary", order = 1)]
public class PowerupDictionary : ScriptableObject
{
    static List<PowerupScriptable> PowerupList = new List<PowerupScriptable>();
    static Dictionary<string, PowerupScriptable> PowerupLookup = new Dictionary<string, PowerupScriptable>();

    public PowerupScriptable ReturnRandomPowerup(){ if (PowerupList.Count == 0) return null; return PowerupList[Random.Range(0, PowerupList.Count)]; }

    public PowerupScriptable ReturnPowerup(string name)
    {
        if (PowerupLookup.TryGetValue(name, out PowerupScriptable powerup))
        {
            return powerup;
        }
        else
        {
            Debug.LogWarning($"Powerup with name {name} not found.");
            return null;
        }
    }
}
 