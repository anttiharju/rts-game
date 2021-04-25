using System.Collections.Generic;
using RtsGame.Units;

namespace RtsGame.GameSystems.Command
{
    public class AttackCommand : ICommand
    {
        private readonly List<Unit> executors;
        private readonly Unit target;

        public AttackCommand(List<Unit> executors, Unit target)
        {
            this.executors = executors;
            this.target = target;
        }

        public void Execute()
        {
            foreach (var unit in executors)
            {
                unit.AddTask(new AttackTask(target));
            }
        }
    }
}
