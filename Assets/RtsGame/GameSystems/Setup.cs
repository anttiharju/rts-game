using System;
using RtsGame.GameSystems.Command;
using RtsGame.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace RtsGame.GameSystems
{
    /// <summary>
    /// Sets up the game system objects and passes Unity callbacks to them.
    /// </summary>
    public class Setup : MonoBehaviour
    {
        [SerializeField] private Faction playerFaction;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private RectangleRenderer rectangleRenderer;

        private CommandManager commandManager;
        private CommandExecutor commandExecutor;
        private SelectionSystem selectionSystem;
        private IRtsInput input;
        private UnityInputWrapper unityInputWrapper;

        private void Awake()
        {
            unityInputWrapper = new UnityInputWrapper(playerInput);
            input = new RtsInput(unityInputWrapper, rectangleRenderer);
            selectionSystem = new SelectionSystem(input, playerFaction);
            commandExecutor = new CommandExecutor();
            commandManager = new CommandManager(
                playerFaction,
                input,
                commandExecutor,
                selectionSystem);
        }

        private void Update()
        {
            commandExecutor.Update();
        }

        private void OnDestroy()
        {
            unityInputWrapper.Dispose();
        }
    }
}
