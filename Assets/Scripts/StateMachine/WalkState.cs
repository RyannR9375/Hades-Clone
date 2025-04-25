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
        
        public void OnMove(InputAction.CallbackContext data)
        {
            player._move = data.ReadValue<Vector2>();
            UnityEngine.Vector3 moveVector = player.Speed * Time.fixedDeltaTime * Time.timeScale * player.transform.TransformDirection(player._move);
            player._rb.linearVelocity = new UnityEngine.Vector3(moveVector.x, 0, moveVector.y);
            //_rb.linearVelocity = new UnityEngine.Vector3(moveVector.x, _rb.linearVelocity.y, moveVector.y);
        }
    }
}