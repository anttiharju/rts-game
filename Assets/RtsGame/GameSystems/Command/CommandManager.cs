using System.Collections.Generic;
using RtsGame.Input;
using RtsGame.Units;
using UnityEngine;

namespace RtsGame.GameSystems.Command
{
    /// <summary>
    /// Generates commands based on input and selected units.
    /// </summary>
    public class CommandManager
    {
        [SerializeField] private Faction faction;
        [SerializeField] private RtsInput rtsInput;
        [SerializeField] private CommandExecutor commandExecutor;
        private SelectionSystem selectionSystem;

        public CommandManager(
            Faction faction,
            RtsInput rtsInput,
            CommandExecutor commandExecutor,
            SelectionSystem selectionSystem)
        {
            this.faction = faction;
            this.rtsInput = rtsInput;
            this.commandExecutor = commandExecutor;
            this.selectionSystem = selectionSystem;

            rtsInput.ActionOnUnit += OnActionOnUnit;
        }

        private void OnActionOnUnit(Unit target)
        {
            if (target.Faction != faction)
                commandExecutor.AddCommand(new AttackCommand(selectionSystem.Selected, target));
        }
    }
}
