using UnityEngine;

namespace RtsGame.Units
{
    public class UnitAnimator
    {
        private readonly Animator animator;
        private static readonly int TakeDamageHash = Animator.StringToHash("TakeDamage");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        
        public UnitAnimator(Animator animator)
        {
            this.animator = animator;
        }
        
        public void TakeDamage()
        {
            animator.SetTrigger(TakeDamageHash);
        }

        public void Attack()
        {
            animator.SetTrigger(AttackHash);
        }
    }
}
