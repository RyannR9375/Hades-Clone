//using UnityEngine;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Schema;

//public class StatModifierActivator : MonoBehaviour
//{
//    void ActivateStatModifier(StatModifierGroup statModifierGroup)
//    {
//        if (statModifierGroup == null) return; //IF THE STAT MODIFIER GROUP IS NULL
//        if (statModifierGroup.StatModifiers.Count == 0) return; //IF EMPTY THEN LEAVE,
//        if (statModifierGroup.ActivateOnce == true && statModifierGroup.Activated == true) return; //IF THE STAT MODIFIER GROUP IS ALREADY ACTIVATED

//        statModifierGroup.Activated = true; //SET THE STAT MODIFIER GROUP TO ACTIVATED
//        foreach (StatModifierSingle x in statModifierGroup.StatModifiers)
//        {
//            if (x == null) return; //IF THE STAT MODIFIER IS NULL
//            if (x.Time == StatTime.Instant)
//            {
//                StatModifierInstant(x);
//            }
//            else if (x.Time == StatTime.Over_Time)
//            {
//                StartCoroutine(StatModifierOverTime(x));
//            }
//        }
//    }

//    ref float FindChangingStat(StatModifierSingle statModifier)
//    {
//        switch (statModifier?.BoonCategory)
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

//    private void StatModifierInstant(StatModifierSingle statModifier)
//    {
//        //DETERMINE BUFF OR DEBUFF
//        float change = statModifier?.Type == StatType.Buff ? statModifier.Change : -(statModifier.Change);
//        FindChangingStat(statModifier) += change;
//    }

//    delegate ref float ChangingVal(StatModifierSingle statModifier);
//    private IEnumerator StatModifierOverTime(StatModifierSingle statModifier)
//    {
//        //Debug.Log("Activating OT...");
//        float totalChange = statModifier.Type == StatType.Buff ? statModifier.Change : -(statModifier.Change);
//        float rate = totalChange / statModifier.TotalTime;
//        float changed = 0f;

//        ChangingVal changingVal = FindChangingStat;

//        while (true)
//        {
//            float maxChangeAllowed = totalChange - changed;
//            float changeOverFrame = Time.deltaTime * rate;


//            if (changeOverFrame > maxChangeAllowed) // Reached max Change
//            {
//                changingVal(statModifier) += maxChangeAllowed; //probably really inefficient ?
//                yield break;
//            }
//            else
//            {
//                changingVal(statModifier) += changeOverFrame;
//                changed += changeOverFrame;
//                yield return null;
//            }
//        }
//    }
//}
