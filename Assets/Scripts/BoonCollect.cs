using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class BoonCollect : MonoBehaviour, IInteractable
{
    [SerializeField] private BoonFamily boonFamily;
    public Action Interact { get; set; }

    public void Start()
    {
        SetInteract(SendRandomBoons);
    }

    public void Update()
    {
        //DEBUG
        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            this.Interact?.Invoke();
        }
    }
    public void SetInteract(Action action)
    {
        this.Interact = action;
    }

    private void SendRandomBoons() { UIManager.Instance.ShowBoonCollectUI(boonFamily.ReturnRandomBoons(3), boonFamily.familyName); } 
}
