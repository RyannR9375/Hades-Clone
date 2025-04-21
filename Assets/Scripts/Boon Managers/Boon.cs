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
    [SerializeReference] private string _boonName;
    public int Tier { get => _tier; set => _tier = value; }
    [SerializeReference] private int _tier;
    public string Description { get => _description; set => _description = value; }
    [SerializeReference, TextArea(5, 10)] private string _description;
    [HideInInspector] public string UniqueName { get => _uniqueName; set => _uniqueName = value; }
    private string _uniqueName;
    public StatModifierGroup StatModifierGroup { get => _statModifierGroup; set => _statModifierGroup = value; }
    [SerializeField] private StatModifierGroup _statModifierGroup;

    [SerializeField] public Action Activate { get; set; }
    public virtual void ActivateBoon() { Debug.Log($"Activating {BoonName}."); }
}
