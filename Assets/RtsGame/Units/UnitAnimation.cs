using UnityEngine;

namespace RtsGame.Units
{
    public class UnitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int TakeDamageHash = Animator.StringToHash("TakeDamage");

        public void TakeDamage()
        {
            animator.SetTrigger(TakeDamageHash);
        }
    }
}
