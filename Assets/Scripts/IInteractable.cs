using UnityEngine;
using System;

public interface IInteractable
{
    public Action Interact { get => this.Interact; set { SetInteract(value); } }
    public virtual void SetInteract(Action action) { this.Interact = action; }
}
