using RtsGame.Input;
using RtsGame.Units;

namespace RtsGame.GameSystems.Command
{
    /// <summary>
    /// Generates commands based on input and selected units.
    /// </summary>
    public class CommandManager
    {
        private Faction faction;
        private CommandExecutor commandExecutor;
        private SelectionSystem selectionSystem;

        public CommandManager(
            Faction faction,
            RtsInput rtsInput,
            CommandExecutor commandExecutor,
            SelectionSystem selectionSystem)
        {
            this.faction = faction;
            this.commandExecutor = commandExecutor;
            this.selectionSystem = selectionSystem;

            rtsInput.ActionOnUnit += OnActionOnUnit;
        }

        private void OnActionOnUnit(Unit target)
        {
            if (target.Faction != faction)
            {
                commandExecutor.AddCommand(new AttackCommand(selectionSystem.Selected, target));
            }
        }
    }
}
