using UnityEngine;

namespace RtsGame.Command
{
    public class CommandExecutor : MonoBehaviour
    {
        private ICommand command;
        public void AddCommand(ICommand attackCommand)
        {
            command = attackCommand;
        }

        private void Update()
        {
            if (command != null)
            {
                command.Execute();
                command = null;
            }
        }
    }
}