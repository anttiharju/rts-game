using System.Collections.Generic;
using RtsGame.Input;
using RtsGame.Units;
using UnityEngine;

namespace RtsGame.Command
{
    /// <summary>
    /// Generates commands based on input and selected units.
    /// </summary>
    public class CommandManager
    {
        [SerializeField] private Faction faction;
        [SerializeField] private List<Unit> selected = new List<Unit>();
        [SerializeField] private RtsInput rtsInput;
        [SerializeField] private CommandExecutor commandExecutor;

        public CommandManager(
            Faction faction,
            RtsInput rtsInput,
            CommandExecutor commandExecutor)
        {
            this.faction = faction;
            this.rtsInput = rtsInput;
            this.commandExecutor = commandExecutor;

            rtsInput.ActionOnUnit += OnActionOnUnit;
            rtsInput.SelectOnUnit += OnSelectUnit;
        }

        private void OnActionOnUnit(Unit target)
        {
            if (target.Faction != faction)
                commandExecutor.AddCommand(new AttackCommand(selected, target));
        }

        private void OnSelectUnit(Unit unit)
        {
            if (unit.Faction == faction)
            {
                selected.Clear();
                selected.Add(unit);
            }
        }
    }
}