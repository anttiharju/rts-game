using UnityEngine;

namespace RtsGame.Command
{
	public abstract class CommandExecutor
	{
		public abstract void AddCommand(ICommand command);
	}
}