using System;
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
        private IUnitTask task;

        private void Awake()
        {
            damageable = new Damageable(health);
            unitAnimation = new UnitAnimation(animator);
            damager = new Damager(damage);
            
            damageable.Damaged += unitAnimation.TakeDamage;
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
            if (task is IDependsOnUnitAnimation dependsOnUnitAnimation) 
                dependsOnUnitAnimation.SetUnitAnimation(unitAnimation);
        }

        private void ClearTask()
        {
            task = null;
        }
    }
}
