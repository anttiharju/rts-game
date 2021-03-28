using UnityEngine;

namespace RtsGame.Command
{
	public abstract class CommandExecutor : MonoBehaviour
	{
		public abstract void AddCommand(ICommand command);
	}
}