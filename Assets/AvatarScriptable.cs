using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AvatarScriptable", order = 1)]
public class AvatarScriptable : ScriptableObject
{
    public float Health;
    public float Damage;
    public float Speed;
    public string AvatarName;
}
