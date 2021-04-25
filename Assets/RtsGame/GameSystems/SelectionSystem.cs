using System.Collections.Generic;
using RtsGame.Input;
using RtsGame.Units;

namespace RtsGame.GameSystems
{
    /// <summary>
    /// Maintains a list of selected Units for a faction.
    /// </summary>
    public class SelectionSystem
    {
        private readonly Faction faction;
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
                UnselectCurrentlySelectedUnits();
                SelectUnit(unit);
            }
        }

        private void UnselectCurrentlySelectedUnits()
        {
            foreach (var previouslySelected in Selected)
            {
                previouslySelected.Selected = false;
            }
            Selected.Clear();
        }

        private void SelectUnit(Unit unit)
        {
            unit.Selected = true;
            Selected.Add(unit);
        }
    }
}
