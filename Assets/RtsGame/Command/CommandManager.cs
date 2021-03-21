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
            commandExecutor.AddCommand(new AttackCommand(selected, target));
        }

        private void OnSelectUnit(Unit obj)
        {
            selected.Clear();
            selected.Add(obj);
        }
    }
}