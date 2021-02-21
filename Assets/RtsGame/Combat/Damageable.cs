using System;
using UnityEngine;

namespace RtsGame.Combat
{
    public class Damageable
    {
        private int health;

        public int Health
        {
            get => health;
            set
            {
                int oldHealth = health;
                health = value;
                
                if (health <= 0)
                {
                    health = 0;
                }

                if (health < oldHealth)
                {
                    Damaged?.Invoke();
                }

                if (health == 0)
                {
                    Death?.Invoke();
                }
            }
        }

        public event Action Death;

        public event Action Damaged;

        public Damageable(int health)
        {
            this.health = health;
        }
    }
}
