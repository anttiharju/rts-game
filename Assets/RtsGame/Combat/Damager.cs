using UnityEngine;

namespace RtsGame.Combat
{
    public class Damager : MonoBehaviour
    {
        public int AttackDamage { get; set; }

        public void Attack(Damageable damageable)
        {
            damageable.Health -= AttackDamage;
        }
    }
}
