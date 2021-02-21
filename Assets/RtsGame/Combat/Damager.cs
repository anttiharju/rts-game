using UnityEngine;

namespace RtsGame.Combat
{
    public class Damager
    {
        public int AttackDamage { get; }

        public void Attack(Damageable damageable)
        {
            damageable.Health -= AttackDamage;
        }

        public Damager(int attackDamage)
        {
            AttackDamage = attackDamage;
        }
    }
}
