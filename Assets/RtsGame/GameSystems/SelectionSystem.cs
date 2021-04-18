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
                Selected.Clear();
                Selected.Add(unit);
            }
        }
    }
}
