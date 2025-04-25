using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoonCollectUIFactory : MonoBehaviour
{
    public static void SetBoonCollectUI(Boon boon, string familyName, Action action, BoonCollectUI passOut)
    {
        passOut.button.onClick.RemoveAllListeners(); //Remove all listeners to prevent multiple activations

        //Set its BoonCollectUI components to the new values
        passOut.familyName.text = familyName;
        passOut.boonName.text = boon.BoonName;
        passOut.description.text = BoonDescriptionFactory.CreateDescription(boon);
        passOut.statUpgrades.text = StatModifierDescriptor.CreateDescription(boon.StatModifierGroup);
        passOut.button.onClick.AddListener(()=>action?.Invoke());
    }
}
