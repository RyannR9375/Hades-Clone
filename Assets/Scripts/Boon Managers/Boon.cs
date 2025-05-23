using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using System;

public interface IBoon
{
    public string BoonName { get; set; }
    public int Tier { get; set; }
    public string Description { get; set; }
    public string UniqueName { get; set; }
    public Action Activate { get; set; } //FOR TESTING PURPOSES, PASSES IN A TIER
    public void ActivateBoon();
}

[System.Serializable, SerializeField]
public class Boon : MonoBehaviour, IBoon
{
    internal void OnEnable() { this.Activate = ActivateBoon; }
    public string BoonName { get => _boonName; set => _boonName = value; }
    [SerializeField] private string _boonName;
    public int Tier { get => _tier; set => _tier = value; }
    [SerializeField] private int _tier;
    public string Description { get => _description; set => _description = value; }
    [SerializeField, TextArea(5, 10)] private string _description;
    public string UniqueName { get => _uniqueName; set => _uniqueName = value; }
    private string _uniqueName;
    public bool CanActivateMoreThanOnce { get => _canActivateMoreThanOnce; set => _canActivateMoreThanOnce = value; }
    [SerializeField] private bool _canActivateMoreThanOnce = false; //IF TRUE, CAN STACK MULTIPLE TIMES
    internal bool _hasActivated = false;

    private StatModifierActivator _statModifierActivator;
    public StatModifierGroup StatModifierGroup { get => _statModifierGroup; set => _statModifierGroup = value; }
    [SerializeField] private StatModifierGroup _statModifierGroup;

    [SerializeField] public Action Activate { get; set; }
    public virtual void ActivateBoon() {
        if (_hasActivated && !CanActivateMoreThanOnce) return; //IF THE BOON HAS ALREADY BEEN ACTIVATED AND CANNOT BE ACTIVATED MORE THAN ONCE
        
        this.ActivateStatModifier();
        Debug.Log($"Activating {BoonName}.");
        _hasActivated = true; //SET TO TRUE SO WE DON'T ACTIVATE AGAIN INCASE
    }
    public void ActivateStatModifier() {
        //IF DID NOT HAVE THE COMPONENT , THEN ADD IT
        if (!TryGetComponent<StatModifierActivator>(out _statModifierActivator)) { 
            _statModifierActivator = gameObject.AddComponent<StatModifierActivator>();
            Debug.LogWarning($"{BoonName} did not have a StatModifierActivator so it was provided one.");
        }

        //IF YOU MADE IT THIS FAR, THEN EVERYTHING'S GOOD, AND YOU CAN ACTIVATE THE STAT MODIFIER
        this._statModifierActivator.ActivateStatModifier(StatModifierGroup);
    }
}

public class BoonDescriptionFactory
{
    public static string CreateDescription(Boon boon)
    {
        string description = boon.Description;
        description = description.Replace("[BoonName]", boon.BoonName);

        int idx = 0;
        if (boon.StatModifierGroup == null || boon.StatModifierGroup.StatModifiers.Count == 0) return description;

        foreach(StatModifierSingle x in boon.StatModifierGroup.StatModifiers)
        {
            if (x == null) continue;
            description = description.Replace($"[TotalTime{idx}]", x.TotalTime.ToString());
            idx++;
        }

        return description;
    }
}
