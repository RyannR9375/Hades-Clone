using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifierSingle : IStatModifier
{
    public StatType Type { get => _type; set => _type = value; }
    [SerializeReference] private StatType _type;
    public StatTime Time { get => _time; set => _time = value; }
    [SerializeReference] private StatTime _time;
    public StatCategory BoonCategory { get => _boonCategory; set => _boonCategory = value; }
    [SerializeReference] private StatCategory _boonCategory;
    public float Change { get => _change; set => _change = value; }
    [SerializeReference] private float _change;
    public float TotalTime { get => _totalTime; set => _totalTime = value; }
    [SerializeReference] private float _totalTime;
}
