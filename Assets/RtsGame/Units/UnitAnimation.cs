using UnityEngine;

namespace RtsGame.Units
{
    public class UnitAnimation
    {
        private readonly Animator animator;
        private static readonly int TakeDamageHash = Animator.StringToHash("TakeDamage");

        public void TakeDamage()
        {
            animator.SetTrigger(TakeDamageHash);
        }

        public UnitAnimation(Animator animator)
        {
            this.animator = animator;
        }
    }
}
