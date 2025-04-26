using HadesClone;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(PlayerController player, Animator animator) : base(player, animator) { }
    public override void OnEnter() {
        Debug.Log("Entered Idle State");
        animator.CrossFade(IdleHash, crossFadeDuration);
    }
}