using System;
using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int health = 100;
        [SerializeField] private int damage = 10;
        [SerializeField] private Faction faction;

        private Damageable damageable;
        private Damager damager;
        private UnitAnimator unitAnimator;
        private IUnitTask task;

        public Faction Faction
        {
            get => faction;
            set => faction = value;
        }

        private void Awake()
        {
            damageable = new Damageable(health);
            unitAnimator = new UnitAnimator(animator);
            damager = new Damager(damage);

            damageable.Damaged += unitAnimator.TakeDamage;
            damageable.Death += Die;
        }

        private void Update()
        {
            task?.Update(this);
        }

        public void DealDamage(Unit target)
        {
            damager.Attack(target.damageable);
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void AddTask(IUnitTask task)
        {
            this.task = task;
            task.Completed += ClearTask;
            if (task is IDependsOnUnitAnimator dependsOnUnitAnimation)
                dependsOnUnitAnimation.SetUnitAnimator(unitAnimator);
        }

        private void ClearTask()
        {
            task = null;
        }
    }
}
