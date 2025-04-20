using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AvatarScriptable", order = 1)]
public class AvatarScriptable : ScriptableObject
{
    public float Health = 0;
    public float Damage = 0;
    public float Speed  = 0;
    public string AvatarName = "";
}
