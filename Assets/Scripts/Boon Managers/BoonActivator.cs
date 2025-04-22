using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;

//WILL BE USED FOR ACTIVATING POWERUPS INSIDE OF THE SCENE
//HAVE SOME SORT OF INTERACT DISTANCE, BRINGS UP A FAMILY OF BOONS
//WILL CREATE AN INSTANCE OF A BOON, AND THEN THE BOON ITSELF WILL BE RESPONSIBLE FOR CONTINUING ANY ACTIVE EFFECTS
public class BoonActivator : MonoBehaviour
{
    public List<BoonFamily> BoonFamilies;
    static public Player Receiving;

    //DEBUG
    private void Start()
    {
        Receiving = Player.Instance; //IN OUR TEST CASE,
        SetUniqueNames();
    }

    private void SetUniqueNames()
    {
        foreach(BoonFamily family in BoonFamilies)
        {
            family.SetUniqueNames();
            foreach(Boon boon in family.Boons)
            {
                //boon.ActivateBoon = BoonDictionary.BoonActions[boon.UniqueName]; //ASSIGN THE BOON AN ACTION
                
            }
        }
    }

    private void Update()
    {
        Activate();
    }

    //DEBUG ACTIVATE ALL BOONS
    void Activate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //TEMP
        {
            //Debug.Log("Attempting to activate...");
            foreach(BoonFamily family in BoonFamilies)
            {
                //Debug.Log($"Activating {family.familyName} Family");
                foreach (Boon boon in family.Boons)
                {
                    //Debug.Log($"Activating {boon.BoonName}");
                    ActivateBoon(boon);
                }
            }
        }
    }

    void ActivateBoon(Boon boon)
    {
        if(boon == null) return;

        //Debug.Log($"Attempting to activate boon: {boon.BoonName}");
        if (BoonManager.Instance.ActiveBoons.ContainsKey(boon.UniqueName))
        {
            BoonManager.Instance.ActiveBoons[boon.UniqueName].Activate?.Invoke(); //ACTIVATE BOON FROM THE DICTIONARY
        }
        else
        {
            Boon instance = Instantiate(boon.gameObject, Receiving.transform.position, Quaternion.identity).GetComponent<Boon>(); //Instantiate the boon prefab if it didnt exist in the dictionary
            instance.Activate?.Invoke(); //Invoke the action associated with the boon
            BoonManager.Instance.ActiveBoons.Add(boon.UniqueName, instance); //Add the boon to the active boons
        }
    }
}
