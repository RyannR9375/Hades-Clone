using System;
using UnityEngine;

public class Boon_JackyProjectile : Boon
{
    private void OnEnable()
    {
        SetActivate(ActivateBoon());
    }

    void SetActivate(Action action)
    {
        Debug.Log("Set Activate Action");
        this.Activate = action;
    }

    Action ActivateBoon()
    {
        return () =>
        {
            // Implement the logic for activating the boon here
            Debug.Log($"ACTIVATION COMPLETE!!!!!!: {BoonName}");
        };
    }
}
