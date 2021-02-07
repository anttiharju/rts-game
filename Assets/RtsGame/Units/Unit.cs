using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Damageable damageable;
        [SerializeField] private UnitAnimation unitAnimation;

        private void Start()
        {
            damageable.Damaged += unitAnimation.TakeDamage;
        }

        [ContextMenu("Test taking damage")]
        public void TestTakingDamage()
        {
            damageable.Health -= 1;
        }
    }
}
