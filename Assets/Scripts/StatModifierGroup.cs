using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat Modifier", menuName = "ScriptableObjects/Stats/Stat Modifier Group", order = 1)]
public class StatModifierGroup : ScriptableObject
{
    public List<StatModifierSingle> StatModifiers = new List<StatModifierSingle>();

    public StatModifierSingle this[int key]
    {
        get => StatModifiers[key];
        set => StatModifiers[key] = value;
    }
}