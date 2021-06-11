using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace Utilities
{
    /// <summary>
    /// Wraps the Unity input system adding drag events and passing mouse position on screen with the events.
    /// </summary>
    public class UnityInputWrapper : IDisposable
    {
        public event Action<Vector2> LeftMouseButtonClicked;
        public event Action<Vector2> RightMouseButtonClicked;
        public event Action<Vector2> LeftMouseButtonDragStart;
        public event Action<Vector2> LeftMouseButtonDragEnd;

        private readonly PlayerInput playerInput;
        private const float DragTriggerDistance = 100;

        private Coroutine updateCoroutine;
        private Vector2 startPosition;
        private bool isDrag;

        public UnityInputWrapper(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            playerInput.actions["Left Mouse Button"].started += OnLeftMouseButtonDown;
            playerInput.actions["Left Mouse Button"].canceled += OnRightMouseButtonUp;
            playerInput.actions["Right Mouse Button"].performed += RightMouseButtonClickPerformed;
        }

        private void RightMouseButtonClickPerformed(InputAction.CallbackContext obj)
        {
            RightMouseButtonClicked?.Invoke(GetMousePosition());
        }

        private void OnLeftMouseButtonDown(InputAction.CallbackContext obj)
        {
            startPosition = GetMousePosition();
            updateCoroutine = CoroutineRunner.Instance.StartCoroutine(Update());
        }

        private void OnRightMouseButtonUp(InputAction.CallbackContext obj)
        {
            CoroutineRunner.Instance.StopCoroutine(updateCoroutine);
            if (isDrag)
            {
                LeftMouseButtonDragEnd?.Invoke(GetMousePosition());
            }
            else
            {
                LeftMouseButtonClicked?.Invoke(startPosition);
            }
            isDrag = false;
        }

        private IEnumerator Update()
        {
            while (true)
            {
                yield return null;
                if (Vector2.Distance(startPosition, GetMousePosition()) > DragTriggerDistance)
                {
                    isDrag = true;
                    LeftMouseButtonDragStart?.Invoke(startPosition);
                }
            }
        }

        private Vector2 GetMousePosition()
        {
            return playerInput.actions["Mouse Position"].ReadValue<Vector2>();
        }

        public void Dispose()
        {
            playerInput.actions["Left Mouse Button"].started -= OnLeftMouseButtonDown;
            playerInput.actions["Left Mouse Button"].canceled -= OnRightMouseButtonUp;
            playerInput.actions["Right Mouse Button"].performed -= RightMouseButtonClickPerformed;
        }
    }
}
