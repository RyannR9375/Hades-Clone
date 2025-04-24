using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoonCollectUIFactory : MonoBehaviour
{
    public static void SetBoonCollectUI(Boon boon, string familyName, Action action, BoonCollectUI passOut)
    {
        passOut.Button.onClick.RemoveAllListeners(); //Remove all listeners to prevent multiple activations

        //Set its BoonCollectUI components to the new values
        passOut.FamilyName.text = familyName;
        passOut.BoonName.text = boon.BoonName;
        passOut.Description.text = BoonDescriptionFactory.CreateDescription(boon);
        passOut.StatUpgrades.text = StatModifierDescriptor.CreateDescription(boon.StatModifierGroup);
        passOut.Button.onClick.AddListener(()=>action?.Invoke());
    }
}
