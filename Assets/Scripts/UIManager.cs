using System.Linq;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject boonMenu;
    [SerializeField] private GameObject boonCollectButton;

    Boon[] boonList;
    //public void ShowBoonCollectUI(Boon[] boonsToDisplay, string familyName)
    //{
    //    if (boonMenu.activeInHierarchy) return; //RETURN IF ALREADY OPEN
    //    if(boonCollectUIList.Length == 0) { Debug.LogError("No Boon Collect UI Set in UIManager.cs"); return; }
    //    boonList = boonsToDisplay;

    //    int idx = 0;
    //    //BoonCollectUIFactory factory = new BoonCollectUIFactory(boonCollectUIList);
    //    foreach (Boon x in boonsToDisplay) //FOR EACH BOON
    //    {
    //        //1 IS FAMILY NAME
    //        //2 IS BOON NAME
    //        //3 IS DESCRIPTION
    //        TextMeshProUGUI[] TXTComponents = boonCollectUIList[idx].GetComponentsInChildren<TextMeshProUGUI>();
    //        TXTComponents[0].text = familyName;
    //        TXTComponents[1].text = x.BoonName;
    //        TXTComponents[2].text = BoonDescriptionFactory.CreateDescription(x);
    //        idx++;
    //    }
    //    boonMenu.SetActive(true);
    //    //GameManager.PauseGame();
    //}

    public void ShowBoonCollectUI(Boon[] boonsToDisplay, string familyName)
    {
        foreach (Boon boon in boonsToDisplay)
        {
            BoonCollectUI boonCollectUI = BoonCollectUIFactory.Empty()
                .WithFamilyName(familyName)
                .WithBoonName(boon.BoonName)
                .WithDescription(BoonDescriptionFactory.CreateDescription(boon))
                .Build();

            //boonCollectUI.
        }
    }

    public void PauseGame()
    {
        GameManager.PauseGame();
    }

    public void CloseBoonCollectMenu()
    {
        boonMenu.SetActive(false);
    }

    public void CloseBoonCollectMenu(GameObject chosen)
    {
        //int idx = boonCollectUIList.ToList().IndexOf(chosen);
        //BoonManager.Instance.ActivateBoon(boonList[idx]);
        boonMenu.SetActive(false);
    }
}
