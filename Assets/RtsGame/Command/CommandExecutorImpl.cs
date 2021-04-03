using UnityEngine;

namespace RtsGame.Command
{
	public class CommandExecutorImpl : CommandExecutor
	{
		private ICommand command;
		public override void AddCommand(ICommand command)
		{
			this.command = command;
		}

		public void Update()
		{
			if (command != null)
			{
				command.Execute();
				command = null;
			}
		}
	}
}
