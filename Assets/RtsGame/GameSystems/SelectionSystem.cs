using System;
using System.Collections.Generic;
using RtsGame.Input;
using RtsGame.Units;
using UnityEngine.Assertions;

namespace RtsGame.GameSystems
{
    /// <summary>
    /// Maintains a list of selected Units for a faction.
    /// </summary>
    public class SelectionSystem
    {
        private readonly Faction faction;
        private readonly Dictionary<Unit, List<Action>> unitSelectionListeners
            = new Dictionary<Unit, List<Action>>();

        public List<Unit> Selected { get; } = new List<Unit>();


        public SelectionSystem(
            RtsInput rtsInput,
            Faction faction)
        {
            rtsInput.SelectOnUnit += OnSelectUnit;
            this.faction = faction;
        }

        private void OnSelectUnit(Unit unit)
        {
            if (unit.Faction == faction)
            {
                Selected.Clear();
                Selected.Add(unit);
                NotifyListeners(unit);
            }
        }

        private void NotifyListeners(Unit unit)
        {
            if (unitSelectionListeners.ContainsKey(unit))
            {
                var listeners = unitSelectionListeners[unit];
                foreach (var listener in listeners)
                {
                    listener();
                }
            }
        }

        public void AddUnitSelectionListener(Unit unit, Action selected)
        {
            if (unitSelectionListeners[unit] == null)
            {
                unitSelectionListeners[unit] = new List<Action> {selected};
            }
            else
            {
                unitSelectionListeners[unit].Add(selected);
            }
        }

        public void RemoveUnitSelectionListener(Unit unit, Action selected)
        {
            Assert.IsTrue(unitSelectionListeners[unit].Contains(selected));
            unitSelectionListeners[unit].Remove(selected);
        }
    }
}
