using System;
using UnityEngine;

namespace RtsGame.Combat
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int health;

        public int Health
        {
            get => health;
            set
            {
                health = value;
                Death?.Invoke();
            }
        }

        public event Action Death;
    }
}
