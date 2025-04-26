using Unity;
using Unity.VisualScripting;
using UnityEngine;

namespace HadesClone
{
    public abstract class BaseState : IState
    {
        protected readonly PlayerController player;
        protected readonly Animator animator;
        
        protected readonly int IdleHash = Animator.StringToHash("Idle");
        protected readonly int WalkHash = Animator.StringToHash("Walk");
        protected readonly int AttackHash = Animator.StringToHash("Attack");

        protected const float crossFadeDuration = 0.1f;
        
        protected BaseState(PlayerController player, Animator animator){
            this.player = player;
            this.animator = animator;
        }
        
        public virtual void OnEnter()
        {
            Debug.Log("Entered Base State");
        }

        public virtual void Update()
        {
           
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void OnChange()
        {
            
        }

        public virtual void OnExit() {
            Debug.Log("Exited Base State");
        }
        
    }
}