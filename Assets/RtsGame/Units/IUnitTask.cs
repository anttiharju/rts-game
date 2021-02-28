using System;

namespace RtsGame.Units
{
    /// <summary>
    /// A task that a Unit is executing.
    /// </summary>
    public interface IUnitTask
    {
        void Update(Unit thisUnit);
        event Action Completed;
    }
}