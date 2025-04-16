using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PowerupHolder : MonoBehaviour
{
    public PowerupScriptable powerupObject;
    public Player receiving;

    //DEBUG
    private void Start()
    {
        receiving = Player.Instance;
    }

    private void Update()
    {
        foreach (Powerup x in powerupObject.powerups) Activate(x);
    }

    void Activate(Powerup powerup)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (powerup.time == PowerupTime.Instant) { PowerUpInstant(powerup); }
            if (powerup.time == PowerupTime.Over_Time) { StartCoroutine(PowerUpOverTime(powerup)); }
        }
    }

    ref float FindChangingValue(Powerup powerup)
    {
        switch (powerup.powerup)
        {
            case PowerupFor.Damage:
                return ref receiving.damage;
            case PowerupFor.Health:
                return ref receiving.currentHealth;
            case PowerupFor.Speed:
                return ref receiving.speed;
            default: 
                return ref receiving.currentHealth;
        }
    }

    private void PowerUpInstant(Powerup powerup)
    {
        if (powerup.change == 0) return;
        //DETERMINE BUFF OR DEBUFF
        float change = powerup.type == PowerupType.Buff ? powerup.change : -(powerup.change);
        FindChangingValue(powerup) += change;
    }
    
    private IEnumerator PowerUpOverTime(Powerup powerup)
    {
        Debug.Log("Activating OT...");
        float totalChange = powerup.type == PowerupType.Buff ? powerup.change : -(powerup.change);
        float rate = totalChange / powerup.totalTime;
        float changed = 0f;

        while (true)
        {
            float maxChangeAllowed = totalChange - changed;
            float changeOverFrame = Time.deltaTime * rate;


            if (changeOverFrame > maxChangeAllowed) // Reached max change
            {
                FindChangingValue(powerup) += maxChangeAllowed; //probably really inefficient
                yield break;
            }
            else
            {
                FindChangingValue(powerup) += changeOverFrame;
                changed += changeOverFrame;
                yield return null;
            }
        }
    }
}
