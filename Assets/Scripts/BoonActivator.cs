using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

//WILL BE USED FOR ACTIVATING POWERUPS INSIDE OF THE SCENE
//HAVE SOME SORT OF INTERACT DISTANCE, BRINGS UP A FAMILY OF BOONS
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
                boon.Activate = BoonDictionary.BoonActions[boon.UniqueName]; //ASSIGN THE BOON AN ACTION
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
                    Activate(boon);
                }
            }
        }
    }

    void Activate(Boon boon)
    {
        if(boon == null) return;

        //if(boon.Activate == null) Debug.Log("Boon has no action to activate"); //!!!!!
        //else Debug.Log($"Activating {boon.BoonName} fr this time.");

        boon.Activate = BoonDictionary.BoonActions[boon.UniqueName]; //ASSIGN THE BOON
        boon.Activate.Invoke(); //Invoke the action associated with the boon

        if (boon.StatModifierGroup.StatModifiers.Count == 0) return;
        foreach (StatModifierSingle x in boon.StatModifierGroup.StatModifiers)
        {
            if (x == null) return; //IF THE STAT MODIFIER IS NULL
            if(x.Time == StatTime.Instant)
            {
                StatModifierInstant(x);
            }
            else if (x.Time == StatTime.Over_Time)
            {
                StartCoroutine(StatModifierOverTime(x));
            }
        }
    }

    ref float FindChangingStat(StatModifierSingle statModifier)
    {
        switch (statModifier?.BoonCategory)
        {
            case StatCategory.Damage:
                return ref Receiving.ReturnReferenceDamage();
            case StatCategory.Health:
                return ref Receiving.ReturnReferenceHealth();
            case StatCategory.Speed:
                return ref Receiving.ReturnReferenceSpeed();
            default:
                return ref Receiving.ReturnReferenceHealth();
        }
    }

    private void StatModifierInstant(StatModifierSingle statModifier)
    {
        //DETERMINE BUFF OR DEBUFF
        float change = statModifier?.Type == StatType.Buff ? statModifier.Change : -(statModifier.Change);
        FindChangingStat(statModifier) += change;
    }
    
    delegate ref float ChangingVal(StatModifierSingle statModifier);
    private IEnumerator StatModifierOverTime(StatModifierSingle statModifier)
    {
        //Debug.Log("Activating OT...");
        float totalChange = statModifier.Type == StatType.Buff ? statModifier.Change : -(statModifier.Change);
        float rate = totalChange / statModifier.TotalTime;
        float changed = 0f;

        ChangingVal changingVal = FindChangingStat;

        while (true)
        {
            float maxChangeAllowed = totalChange - changed;
            float changeOverFrame = Time.deltaTime * rate;


            if (changeOverFrame > maxChangeAllowed) // Reached max Change
            {
                changingVal(statModifier) += maxChangeAllowed; //probably really inefficient ?
                yield break;
            }
            else
            {
                changingVal(statModifier) += changeOverFrame;
                changed += changeOverFrame;
                yield return null;
            }
        }
    }
}
