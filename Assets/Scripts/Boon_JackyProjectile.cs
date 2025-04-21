using System;
using UnityEngine;

public class Boon_JackyProjectile : Boon
{
    public GameObject ProjectilePrefab;
    private void Start()
    {
        this.Activate = ActivateBoon;
    }

    void SetActivate(Action action)
    {
        Debug.Log("Set Activate Action");
        this.Activate = action;
        Debug.Log($"Action set to: {this.Activate}");
    }

    void ActivateBoon()
    {
            // Implement the logic for activating the boon here
            Debug.Log($"ACTIVATION COMPLETE!!!!!!: {BoonName}");
    }
}
