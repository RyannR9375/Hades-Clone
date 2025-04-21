//using System.Collections;
//using System.Collections.Generic;
//using System.Xml.Schema;
//using UnityEngine;

////WILL BE USED FOR ACTIVATING POWERUPS INSIDE OF THE SCENE
////HAVE SOME SORT OF INTERACT DISTANCE, BRINGS UP A FAMILY OF BOONS
//public class BoonActivator : MonoBehaviour
//{
//    public BoonHolder BoonHolder;
//    static public Player Receiving;

//    //DEBUG
//    private void Start()
//    {
//        Receiving = Player.Instance; //IN OUR TEST CASE,
//        //BoonHolder.SetUniqueNames();
//    }

//    private void Update()
//    {
//        ActivateBoon();
//    }

//    void ActivateBoon()
//    {
//        if (Input.GetKeyDown(KeyCode.Space)) //TEMP
//        {
//            if (BoonHolder == null) return; //NO BOON OBJECT
//            if (BoonHolder.BoonFamilies == null || BoonHolder.BoonFamilies.Count == 0) return; //EMPTY LIST OF FAMILIES
//            foreach (BoonFamily family in BoonHolder.BoonFamilies)
//            {
//                BoonHolder.Main();
//                foreach (Boon powerup in family.ActiveBoons)
//                {
//                    if (powerup.Time == StatTime.Instant)   { StatModifierInstant(powerup); }
//                    if (powerup.Time == StatTime.Over_Time) { StartCoroutine(StatModifierOverTime(powerup)); }
//                }
//            }
//        }
//    }

//    ref float FindChangingStat(Boon boon)
//    {
//        switch (boon.BoonCategory)
//        {
//            case StatCategory.Damage:
//                return ref Receiving.ReturnReferenceDamage();
//            case StatCategory.Health:
//                return ref Receiving.ReturnReferenceHealth();
//            case StatCategory.Speed:
//                return ref Receiving.ReturnReferenceSpeed();
//            default:
//                return ref Receiving.ReturnReferenceHealth();
//        }
//    }


//    private void StatModifierInstant(Boon boon)
//    {
//        if (boon.Change == 0) return;
//        //DETERMINE BUFF OR DEBUFF
//        float change = boon.Type == StatType.Buff ? boon.Change : -(boon.Change);
//        FindChangingStat(boon) += change;
//    }
    
//    delegate ref float ChangingVal(Boon boon);
//    private IEnumerator StatModifierOverTime(Boon boon)
//    {
//        //Debug.Log("Activating OT...");
//        float totalChange = boon.Type == StatType.Buff ? boon.Change : -(boon.Change);
//        float rate = totalChange / boon.TotalTime;
//        float changed = 0f;

//        ChangingVal changingVal = FindChangingStat;

//        while (true)
//        {
//            float maxChangeAllowed = totalChange - changed;
//            float changeOverFrame = Time.deltaTime * rate;


//            if (changeOverFrame > maxChangeAllowed) // Reached max Change
//            {
//                changingVal(boon) += maxChangeAllowed; //probably really inefficient ?
//                yield break;
//            }
//            else
//            {
//                changingVal(boon) += changeOverFrame;
//                changed += changeOverFrame;
//                yield return null;
//            }
//        }
//    }
//}
