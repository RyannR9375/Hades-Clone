using UnityEngine;
using UnityEngine.InputSystem;

namespace HadesClone {
    public class WalkState : BaseState {
        public WalkState(PlayerController player, Animator animator) : base(player, animator) {

        }
        
        
        public override void OnEnter() {
            Debug.Log("Entered Walk State");
            animator.CrossFade(WalkHash, crossFadeDuration);
        }

        public override void FixedUpdate() {
            //call players move logic 
        }
    }
}