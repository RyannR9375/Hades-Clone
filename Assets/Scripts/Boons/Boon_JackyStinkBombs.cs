using System;
using UnityEngine;

public class Boon_JackyStinkBombs : Boon
{
    public GameObject ProjectilePrefab;

    override public void ActivateBoon()
    {
        InvokeRepeating(nameof(Activation), 0f, 4f);
    }

    void Activation()
    {
        Instantiate(ProjectilePrefab, Player.Instance.transform.position, Quaternion.identity);
        base.ActivateStatModifier();
    }

}
