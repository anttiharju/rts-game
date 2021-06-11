using System;
using System.Collections;
using RtsGame.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace RtsGame.Input
{
    public class RtsInput
    {
        public event Action<Vector2> Select;
        public event Action<Vector2> DragStart;
        public event Action<Vector2> DragEnd;

        private readonly PlayerInput playerInput;
        private const float DragTriggerDistance = 100;

        private Coroutine updateCoroutine;
        private Vector2 startPosition;
        private bool isDrag;

        public RtsInput(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            playerInput.actions["Select"].started += OnMouseDown;
            playerInput.actions["Select"].canceled += OnMouseUp;
        }

        private void OnMouseDown(InputAction.CallbackContext obj)
        {
            startPosition = GetMousePosition();
            updateCoroutine = CoroutineRunner.Instance.StartCoroutine(Update());
        }

        private void OnMouseUp(InputAction.CallbackContext obj)
        {
            CoroutineRunner.Instance.StopCoroutine(updateCoroutine);
            if (isDrag)
            {
                DragEnd?.Invoke(GetMousePosition());
            }
            else
            {
                Select?.Invoke(startPosition);
            }
            isDrag = false;
        }

        private IEnumerator Update()
        {
            yield return null;
            if (Vector2.Distance(startPosition, GetMousePosition()) > DragTriggerDistance)
            {
                isDrag = true;
                DragStart?.Invoke(startPosition);
            }
        }

        private Vector2 GetMousePosition()
        {
            return playerInput.actions["Mouse Position"].ReadValue<Vector2>();
        }
    }
}
