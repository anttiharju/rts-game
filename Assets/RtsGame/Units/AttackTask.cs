using System;

namespace RtsGame.Units
{
    public class AttackTask : IUnitTask
    {
        private readonly Unit target;

        public AttackTask(Unit target)
        {
            this.target = target;
        }
        
        public void Update(Unit thisUnit)
        {
            thisUnit.DealDamage(target);
            Completed?.Invoke();
        }

        public event Action Completed;
    }
}