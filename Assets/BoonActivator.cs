using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

//WILL BE USED FOR ACTIVATING POWERUPS INSIDE OF THE SCENE
//HAVE SOME SORT OF INTERACT DISTANCE, BRINGS UP A FAMILY OF BOONS
public class BoonActivator : MonoBehaviour
{
    public BoonHolder boonHolder;
    static public Player receiving;

    //DEBUG
    private void Start()
    {
        receiving = Player.Instance; //IN OUR TEST CASE,
        //boonHolder.SetUniqueNames();
    }

    private void Update()
    {
        Activate();
    }

    void Activate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //TEMP
        {
            if (boonHolder == null) return; //NO BOON OBJECT
            if (boonHolder.BoonFamilies == null || boonHolder.BoonFamilies.Count == 0) return; //EMPTY LIST OF FAMILIES
            foreach (BoonFamily family in boonHolder.BoonFamilies)
            {
                foreach (Boon powerup in family.Powerups)
                {
                    if (powerup.time == BoonTime.Instant)   { BoonInstant(powerup); }
                    if (powerup.time == BoonTime.Over_Time) { StartCoroutine(BoonOverTime(powerup)); }
                }
            }
        }
    }

    ref float FindChangingValue(Boon boon)
    {
        switch (boon.powerup)
        {
            case BoonFor.Damage:
                return ref receiving.ReturnReferenceDamage();
            case BoonFor.Health:
                return ref receiving.ReturnReferenceHealth();
            case BoonFor.Speed:
                return ref receiving.ReturnReferenceSpeed();
            default:
                return ref receiving.ReturnReferenceHealth();
        }
    }


    private void BoonInstant(Boon boon)
    {
        if (boon.change == 0) return;
        //DETERMINE BUFF OR DEBUFF
        float change = boon.type == BoonType.Buff ? boon.change : -(boon.change);
        FindChangingValue(boon) += change;
    }
    
    delegate ref float ChangingVal(Boon boon);
    private IEnumerator BoonOverTime(Boon boon)
    {
        //Debug.Log("Activating OT...");
        float totalChange = boon.type == BoonType.Buff ? boon.change : -(boon.change);
        float rate = totalChange / boon.totalTime;
        float changed = 0f;

        ChangingVal changingVal = FindChangingValue;

        while (true)
        {
            float maxChangeAllowed = totalChange - changed;
            float changeOverFrame = Time.deltaTime * rate;


            if (changeOverFrame > maxChangeAllowed) // Reached max change
            {
                changingVal(boon) += maxChangeAllowed; //probably really inefficient ?
                yield break;
            }
            else
            {
                changingVal(boon) += changeOverFrame;
                changed += changeOverFrame;
                yield return null;
            }
        }
    }
}
