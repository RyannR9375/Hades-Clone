using System.Linq;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Pool;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject boonMenu; //CONTAINER
    [SerializeField] private GameObject boonCollectUIPrefab; //PREFAB

    Boon[] boonList;
    static readonly List<GameObject> boonCollectUI = new List<GameObject>();

    //REFACTOR TO OBJECT POOLING
    public void ShowBoonCollectUI(Boon[] boonsToDisplay, string familyName)
    {
        if (boonsToDisplay.Length == 0) { Debug.LogWarning("No boons to display array was passed in 'UIManager.cs'->ShowBoonCollectUI."); return; }


        //ClearAndDestroy<GameObject>.Dispose(boonCollectUI);

        int idx = 0;
        foreach (Boon boon in boonsToDisplay)
        {

            if (boonCollectUI.Count >= boonsToDisplay.Length)
            {
                    BoonCollectUIFactory.SetBoonCollectUI(
                    boon,
                    familyName,
                    () => { BoonManager.Instance.ActivateBoon(boon); DisplayBoonCollectMenu(false); },
                    boonCollectUI[idx].GetComponent<BoonCollectUI>());
            }
            else
            {

                GameObject newBoonCollectUIObject = Instantiate(boonCollectUIPrefab, boonMenu.transform); //Instantiate a new boonCollectUIPrefab
                                                                                                          //CREATE A 'BoonCollectUI' FOR EACH BOON PASSED TO US
                if (!newBoonCollectUIObject.TryGetComponent<BoonCollectUI>(out BoonCollectUI newBoonCollectUI))
                {
                    Debug.LogWarning($"Could not retrive 'BoonCollectUI' from {boonCollectUIPrefab.name}.");
                    continue;
                }

                BoonCollectUIFactory.SetBoonCollectUI(
                    boon,
                    familyName,
                    () => { BoonManager.Instance.ActivateBoon(boon); DisplayBoonCollectMenu(false); },
                    newBoonCollectUI);

                boonCollectUI.Add(newBoonCollectUIObject);
            }
            idx++;
        }

        
        //DISPLAY THE UI
        DisplayBoonCollectMenu(true);
    }

    public void DisplayBoonCollectMenu(bool set) => boonMenu.SetActive(set);

    public void PauseGame() => GameManager.PauseGame();
}

public class ClearAndDestroy<T> : MonoBehaviour
{
    public static void Dispose(List<T> list)
    {
        foreach (T item in list)
        {
            if (item != null)
            {
                Destroy(item as UnityEngine.Object);
            }
        }
        list.Clear();
    }
}
