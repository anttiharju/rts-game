using RtsGame.Command;
using System.Collections.Generic;

namespace RtsGame.Tests
{
	public class CommandExecutorStub : CommandExecutor
	{
		public List<ICommand> commands = new List<ICommand>();

		public override void AddCommand(ICommand command)
		{
			commands.Add(command);	
		}
	}
}
