using System;
using UnityEngine;

public class Boon_JackyProjectile : Boon
{
    public GameObject ProjectilePrefab;

    override public void ActivateBoon()
    {
        Instantiate(ProjectilePrefab, Player.Instance.transform.position, Quaternion.identity);
        //base.ActivateStatModifiers();
    }

    private void Start()
    {
        InvokeRepeating(nameof(ActivateBoon), 0, 4f);
    }

}
