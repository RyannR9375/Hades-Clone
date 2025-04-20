using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PowerupHolder : MonoBehaviour
{
    public PowerupScriptable powerupObject;
    static public Player receiving;

    //DEBUG
    private void Start()
    {
        receiving = Player.Instance; //IN OUR TEST CASE,
    }

    private void Update()
    {
        Activate();
    }

    void Activate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Powerup x in powerupObject.powerups)
            {
                if (x.time == PowerupTime.Instant) { PowerUpInstant(x); }
                if (x.time == PowerupTime.Over_Time) { StartCoroutine(PowerUpOverTime(x)); }
            }
        }
    }

    ref float FindChangingValue(Powerup powerup)
    {
        switch (powerup.powerup)
        {
            case PowerupFor.Damage:
                return ref receiving.ReturnReferenceDamage();
            case PowerupFor.Health:
                return ref receiving.ReturnReferenceHealth();
            case PowerupFor.Speed:
                return ref receiving.ReturnReferenceSpeed();
            default:
                return ref receiving.ReturnReferenceHealth();
        }
    }


    private void PowerUpInstant(Powerup powerup)
    {
        if (powerup.change == 0) return;
        //DETERMINE BUFF OR DEBUFF
        float change = powerup.type == PowerupType.Buff ? powerup.change : -(powerup.change);
        FindChangingValue(powerup) += change;
    }
    
    delegate ref float ChangingVal(Powerup powerup);
    private IEnumerator PowerUpOverTime(Powerup powerup)
    {
        //Debug.Log("Activating OT...");
        float totalChange = powerup.type == PowerupType.Buff ? powerup.change : -(powerup.change);
        float rate = totalChange / powerup.totalTime;
        float changed = 0f;

        ChangingVal changingVal = FindChangingValue;

        while (true)
        {
            float maxChangeAllowed = totalChange - changed;
            float changeOverFrame = Time.deltaTime * rate;


            if (changeOverFrame > maxChangeAllowed) // Reached max change
            {
                changingVal(powerup) += maxChangeAllowed; //probably really inefficient ?
                yield break;
            }
            else
            {
                changingVal(powerup) += changeOverFrame;
                changed += changeOverFrame;
                yield return null;
            }
        }
    }
}
