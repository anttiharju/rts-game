using System;

namespace RtsGame.Units
{
    public class AttackTask : IUnitTask, IDependsOnUnitAnimator
    {
        private readonly Unit target;

        private UnitAnimator unitAnimator;
        
        public AttackTask(Unit target)
        {
            this.target = target;
        }
        
        public void Update(Unit thisUnit)
        {
            PerformAttack(thisUnit);
        }

        private void PerformAttack(Unit attacker)
        {
            attacker.DealDamage(target);
            unitAnimator.Attack();
            Completed?.Invoke();
        }

        public event Action Completed;
        
        public void SetUnitAnimator(UnitAnimator unitAnimator)
        {
            this.unitAnimator = unitAnimator;
        }
    }
}