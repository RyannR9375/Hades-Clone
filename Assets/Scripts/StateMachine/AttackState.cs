using UnityEngine;
using UnityEngine.InputSystem;

namespace HadesClone {
    public class AttackState : BaseState {
        public AttackState(PlayerController player, Animator animator) : base(player, animator) { }

        public override void OnEnter() {
            Debug.Log("Entered Attack State");
            animator.CrossFade(AttackHash, crossFadeDuration);
            player.StartCoroutine(player.HandleAttack());
        }

        public override void Update() {
            //call players jump and move logic
        }
    }
}