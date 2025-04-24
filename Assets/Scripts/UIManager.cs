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

        int idx = 0;
        foreach (Boon boon in boonsToDisplay)
        {
            GameObject toAlter = null;
            //IF WE DON'T HAVE ENOUGH UI ELEMENTS, CREATE THEM
            if ((boonCollectUI.Count < boonsToDisplay.Length))
            {
                for (int i = 0; i < boonsToDisplay.Length - boonCollectUI.Count; ++i)
                {
                    //INSTANTIATE, BUT IF IT DOESN'T HAVE WHAT WE NEED, DESTROY IT AND CONTINUE
                    toAlter = Instantiate(boonCollectUIPrefab, boonMenu.transform);
                    if (!toAlter.TryGetComponent<BoonCollectUI>(out BoonCollectUI newBoonCollectUI))
                    {
                        Debug.LogWarning($"Could not retrive 'BoonCollectUI' from {boonCollectUIPrefab.name}.");
                        Destroy(toAlter);
                        continue;
                    }
                    boonCollectUI.Add(toAlter);
                }
            }
            else { toAlter = boonCollectUI[idx]; } //IF WE HAVE ENOUGH UI ELEMENTS, THEN JUST REUSE THEM

            BoonCollectUIFactory.SetBoonCollectUI
                (
                    boon,
                    familyName,
                    () => { BoonManager.Instance.ActivateBoon(boon); DisplayBoonCollectMenu(false); },
                    toAlter.GetComponent<BoonCollectUI>()
                );
            idx++;
        }
        //DISPLAY THE UI
        DisplayBoonCollectMenu(true);
    }

    public void DisplayBoonCollectMenu(bool set) => boonMenu.SetActive(set);

    public void PauseGame() => GameManager.PauseGame();
}
