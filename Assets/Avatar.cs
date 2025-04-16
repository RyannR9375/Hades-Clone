using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Avatar", order = 1)]
public class Avatar : ScriptableObject
{
    public float Health;
    public float Damage;
    public float Speed;
    public string AvatarName;
}
