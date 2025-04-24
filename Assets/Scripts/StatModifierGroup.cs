using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat Modifier", menuName = "ScriptableObjects/Stats/Stat Modifier Group", order = 1)]
public class StatModifierGroup : ScriptableObject
{
    public bool activateOnce = false;
    public List<StatModifierSingle> StatModifiers = new List<StatModifierSingle>();

    public StatModifierSingle this[int key]
    {
        get => StatModifiers[key];
        set => StatModifiers[key] = value;
    }
}

public class StatModifierDescriptor
{
    public static string CreateDescription(StatModifierGroup statModifierGroup)
    {
        StringBuilder stringBuilder = new();

        foreach(StatModifierSingle statModifier in statModifierGroup.StatModifiers)
        {
            bool isPositive = statModifier.Type == StatType.Buff ? true : false;
            bool isInstant  = statModifier.Time == StatTime.Instant ? true : false;
            string statCategory = statModifier.BoonCategory.ToString();
            string change = statModifier.Change.ToString();
            string totalTime = statModifier.TotalTime.ToString();
            stringBuilder.AppendLine($"{statCategory}: {(isPositive ? '+' : '-' )} {change} {(isInstant ? "" : $"Over {totalTime}s")}");
        }

        return stringBuilder.ToString();
    }
}