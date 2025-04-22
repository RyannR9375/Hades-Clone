using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;

//WILL BE USED FOR ACTIVATING POWERUPS INSIDE OF THE SCENE
//HAVE SOME SORT OF INTERACT DISTANCE, BRINGS UP A FAMILY OF BOONS
//WILL CREATE AN INSTANCE OF A BOON, AND THEN THE BOON ITSELF WILL BE RESPONSIBLE FOR CONTINUING ANY ACTIVE EFFECTS
public class BoonManager : Singleton<BoonManager>
{
    public Dictionary<string, Boon> ActiveBoons = new Dictionary<string, Boon>();
    public List<BoonFamily> BoonFamilies;
    static public Player Receiving;

    //DEBUG

    private new void Awake()
    {
        base.Awake();
    }

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

    public void ActivateBoon(Boon boon)
    {
        if(boon == null) return;

        //Debug.Log($"Attempting to activate boon: {boon.BoonName}");
        if (ActiveBoons.ContainsKey(boon.UniqueName))
        {
            ActiveBoons[boon.UniqueName].ActivateBoon(); //ACTIVATE BOON FROM THE DICTIONARY
        }
        else
        {
            Boon instance = Instantiate(boon.gameObject, Receiving.transform).GetComponent<Boon>(); //Instantiate the boon prefab if it didnt exist in the dictionary
            instance.ActivateBoon(); //Invoke the action associated with the boon
            ActiveBoons.Add(boon.UniqueName, instance); //Add the boon to the active boons
        }
    }
}
