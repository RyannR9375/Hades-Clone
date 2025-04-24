using System;
using System.Collections;
using UnityEngine;

public class Boon_JackyStinkBombs : Boon
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float explosionTime = 2f;
    [SerializeField] float explosionForce = 2000f;
    [SerializeField] float explosionRadius = 2f;

    override public void ActivateBoon()
    {
        Debug.Log($"Activating {BoonName}.");
        InvokeRepeating(nameof(Activation), 0f, 4f);
    }

    void Activation()
    {
        GameObject current = Instantiate(ProjectilePrefab, Player.Instance.transform.position, Quaternion.identity);
        StartCoroutine(Explode(current));
        base.ActivateStatModifier();
    }

    //super sloppy will fix w/ object pooling etc.
    private IEnumerator Explode(GameObject current)
    {
        yield return new WaitForSeconds(explosionTime);
        // Add explosion logic here
        Collider[] colliders = Physics.OverlapSphere(current.transform.position, explosionRadius);

        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb && rb != Player.Instance._rb) rb.AddExplosionForce(explosionForce * Tier, current.transform.position, explosionRadius);
        }

        Destroy(current);
        Debug.Log("BOOM!");
    }

}
