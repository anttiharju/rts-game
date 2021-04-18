using System.Collections.Generic;
using RtsGame.Units;

namespace RtsGame.GameSystems.Command
{
    public class AttackCommand : ICommand
    {
        private readonly List<Unit> selected;
        private readonly Unit target;

        public AttackCommand(List<Unit> selected, Unit target)
        {
            this.selected = selected;
            this.target = target;
        }

        public void Execute()
        {
            foreach (var unit in selected)
            {
                unit.AddTask(new AttackTask(target));
            }
        }
    }
}
