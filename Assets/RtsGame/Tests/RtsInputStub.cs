using System;
using RtsGame.Input;
using RtsGame.Units;

namespace RtsGame.Tests
{
	public class RtsInputStub : IRtsInput
	{
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;

		public void TriggerActionOnUnit(Unit unit)
		{
			ActionOnUnit?.Invoke(unit);
		}

		public void TriggerSelectOnUnit(Unit unit)
		{
            SelectOnUnit?.Invoke(unit);
		}
    }
}
