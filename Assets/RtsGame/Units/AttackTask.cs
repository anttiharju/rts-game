using System;

namespace RtsGame.Units
{
    public class AttackTask : IUnitTask, IDependsOnUnitAnimation
    {
        private readonly Unit target;

        private UnitAnimation unitAnimation;
        
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
            unitAnimation.Attack();
            Completed?.Invoke();
        }

        public event Action Completed;
        
        public void SetUnitAnimation(UnitAnimation unitAnimation)
        {
            this.unitAnimation = unitAnimation;
        }
    }
}