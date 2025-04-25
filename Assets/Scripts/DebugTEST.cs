using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugTEST : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] List<TextMeshProUGUI> txtList = new List<TextMeshProUGUI> ();

    //DEBUG
    private void Update()
    {
        txtList[0].SetText("Name: " + playerController.PlayerName);
        txtList[1].SetText("Current Health: " + playerController.CurrentHealth.ToString("F2"));
        txtList[2].SetText("Current Damage: " + playerController.Damage.ToString("F2"));
        txtList[3].SetText("Current Speed:  " + playerController.Speed.ToString("F2"));
        txtList[4].SetText("Current Max Health: " + playerController.MaxHealth.ToString("F2"));
    }
}
