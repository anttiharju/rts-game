using RtsGame.Input;
using RtsGame.Units;

namespace RtsGame.Tests
{
	public class RtsInputStub : RtsInput
	{
		public void TriggerActionOnUnit(Unit unit)
		{
			OnActionOnUnit(unit);
		}

		public void TriggerSelectOnUnit(Unit unit)
		{
			OnSelectOnUnit(unit);
		}
	}
}