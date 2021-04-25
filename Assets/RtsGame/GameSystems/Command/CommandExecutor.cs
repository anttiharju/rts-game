namespace RtsGame.GameSystems.Command
{
    public class CommandExecutor : ICommandExecutor
    {
        private ICommand command;
        public void AddCommand(ICommand command)
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
