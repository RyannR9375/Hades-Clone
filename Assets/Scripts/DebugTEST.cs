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
        txtList[1].SetText("Current Health: " + player.CurrentHealth.ToString("F2"));
        txtList[2].SetText("Current Damage: " + player.Damage.ToString("F2"));
        txtList[3].SetText("Current Speed:  " + player.Speed.ToString("F2"));
        txtList[4].SetText("Current Max Health: " + player.MaxHealth.ToString("F2"));
    }
}
