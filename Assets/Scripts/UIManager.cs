using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject boonMenu;
    [SerializeField] private GameObject[] boonCollectUIList;
    //[SerializeField] private BoonCollectUIFactory boonCollectUI;

    public void ShowBoonCollectUI(Boon[] boonsToDisplay, string familyName)
    {
        if (boonCollectUIList.Length == 0) { Debug.LogError("No Boon Collect UI Set in UIManager.cs"); return; }

        int idx = 0;
        //BoonCollectUIFactory factory = new BoonCollectUIFactory(boonCollectUIList);
        foreach (Boon x in boonsToDisplay) //FOR EACH BOON
        {
            //1 IS FAMILY NAME
            //2 IS BOON NAME
            //3 IS DESCRIPTION
            TextMeshProUGUI[] TXTComponents = boonCollectUIList[idx].GetComponentsInChildren<TextMeshProUGUI>();
            TXTComponents[0].text = familyName;
            TXTComponents[1].text = x.BoonName;
            TXTComponents[2].text = BoonDescriptionFactory.CreateDescription(x);
            idx++;
        }
        boonMenu.SetActive(true);
        //GameManager.PauseGame();
    }

    public void PauseGame()
    {
        GameManager.PauseGame();
    }

    public void CloseBoonCollectMenu()
    {
        boonMenu.SetActive(false);
    }
}
