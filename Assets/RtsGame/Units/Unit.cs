using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Units
{
    public class Unit : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] private Animator animator;
        [SerializeField] private int health = 100;
        [SerializeField] private int damage = 10;
        #pragma warning restore 0649

        private Damageable damageable;
        private Damager damager;
        private UnitAnimation unitAnimation;

        private void Awake()
        {
            damageable = new Damageable(health);
            unitAnimation = new UnitAnimation(animator);
            damager = new Damager(damage);
            
            damageable.Damaged += unitAnimation.TakeDamage;
        }

        [ContextMenu("Test taking damage")]
        public void TestTakingDamage()
        {
            damageable.Health -= 1;
        }
    }
}
