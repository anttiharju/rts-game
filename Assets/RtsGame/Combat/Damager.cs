using UnityEngine;

namespace RtsGame.Combat
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int attackDamage;

        public int AttackDamage
        {
            get => attackDamage;
            set => attackDamage = value;
        }

        public void Attack(Damageable damageable)
        {
            damageable.Health -= AttackDamage;
        }
    }
}
