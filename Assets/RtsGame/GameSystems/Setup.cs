using RtsGame.GameSystems.Command;
using RtsGame.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.GameSystems
{
    /// <summary>
    /// Sets up the game system objects and passes Unity callbacks to them.
    /// </summary>
    public class Setup : MonoBehaviour
    {
        [SerializeField] private Faction playerFaction;
        [SerializeField] private PlayerInput playerInput;

        private CommandManager commandManager;
        private CommandExecutor commandExecutor;
        private SelectionSystem selectionSystem;
        private IRtsInput rtsInput;

        private void Awake()
        {
            rtsInput = new UnityRtsInput(playerInput);
            selectionSystem = new SelectionSystem(rtsInput, playerFaction);
            commandExecutor = new CommandExecutor();
            commandManager = new CommandManager(
                playerFaction,
                rtsInput,
                commandExecutor,
                selectionSystem);
        }

        private void Update()
        {
            commandExecutor.Update();
        }
    }
}
