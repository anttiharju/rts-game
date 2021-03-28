using System.Collections.Generic;
using RtsGame.Input;
using RtsGame.Units;
using UnityEngine;

namespace RtsGame.Command
{
    /// <summary>
    /// Generates commands based on input and selected units.
    /// </summary>
    public class CommandManager : MonoBehaviour
    {
        [SerializeField] private Faction faction;
        [SerializeField] private List<Unit> selected;
        [SerializeField] private RtsInput rtsInput;
        [SerializeField] private CommandExecutor commandExecutor;

        private void Awake()
        {
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