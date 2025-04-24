using UnityEngine;

public class Boon_GordonCircles : Boon
{
    [SerializeField] GameObject circle;
    [SerializeField] int numOfCircles;

    public override void ActivateBoon()
    {
        Debug.Log($"Activating {BoonName}.");
        for (int i = 0; i < numOfCircles; ++i)
        {
            GameObject newCircle = Instantiate(circle, transform.position, Quaternion.identity);
            newCircle.GetComponent<CirclingObject>().angle += (360/numOfCircles) * i;
        }
    }

}
