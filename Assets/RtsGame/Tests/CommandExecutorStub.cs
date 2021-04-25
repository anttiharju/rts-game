using System.Collections.Generic;
using RtsGame.GameSystems.Command;

namespace RtsGame.Tests
{
	public class CommandExecutorStub : ICommandExecutor
	{
		public List<ICommand> commands = new List<ICommand>();

		public void AddCommand(ICommand command)
		{
			commands.Add(command);
		}
	}
}
