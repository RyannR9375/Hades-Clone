using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugTEST : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] List<TextMeshProUGUI> txtList = new List<TextMeshProUGUI> ();

    //DEBUG
    private void Update()
    {
        txtList[0].SetText("Name: " + player.PlayerName);
        txtList[1].SetText("Current Health: " + player.currentHealth.ToString("F2"));
        txtList[2].SetText("Current Damage: " + player.damage.ToString("F2"));
        txtList[3].SetText("Current Speed:  " + player.speed.ToString("F2"));
        txtList[4].SetText("Current Max Health: " + player.maxHealth.ToString("F2"));
    }
}
