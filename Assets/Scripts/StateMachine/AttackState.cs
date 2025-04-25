using UnityEngine;
using UnityEngine.InputSystem;

namespace HadesClone {
    public class AttackState : BaseState {
        public AttackState(PlayerController player, Animator animator) : base(player, animator) { }

        public override void OnEnter() {
            Debug.Log("Entered Attack State");
            animator.CrossFade(AttackHash, crossFadeDuration);
        }

        public override void FixedUpdate() {
            //call players jump and move logic
            Debug.Log("Entered Attack State");
            player.StartCoroutine(player.HandleAttack());
        }
    }
}