using RtsGame.Command;
using RtsGame.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame
{
    /// <summary>
    /// Sets up the game system objects and passes Unity callbacks to them.
    /// </summary>
    public class GameSystems : MonoBehaviour
    {
        [SerializeField] private Faction playerFaction;
        [SerializeField] private PlayerInput playerInput;

        private CommandManager commandManager;
        private CommandExecutorImpl commandExecutor;

        private void Awake()
        {
            commandExecutor = new CommandExecutorImpl();
            commandManager = new CommandManager(
                playerFaction,
                new UnityRtsInput(playerInput),
                commandExecutor);
        }

        private void Update()
        {
            commandExecutor.Update();
        }
    }
}
