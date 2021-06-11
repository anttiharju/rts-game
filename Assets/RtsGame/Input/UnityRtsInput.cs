using System;
using RtsGame.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.Input
{
    public class UnityRtsInput : IRtsInput
    {
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;

        private int layerMaskUnit;
        private PlayerInput playerInput;
        private RectangleRenderer rectangleRenderer;

        public UnityRtsInput(PlayerInput playerInput, RectangleRenderer rectangleRenderer)
        {
            this.playerInput = playerInput;
            playerInput.actions["Action"].started += (x) => Debug.Log("Action started");
            playerInput.actions["Action"].performed += (x) => Debug.Log("Action performed");
            playerInput.actions["Action"].canceled += (x) => Debug.Log("Action canceled");
            playerInput.actions["Action"].performed += ActionPerformed;
            playerInput.actions["Select"].performed += SelectPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
            this.rectangleRenderer = rectangleRenderer;
        }

        private void ActionPerformed(InputAction.CallbackContext obj)
        {
            var clickedOn = GetClickedUnit();
            if (clickedOn != null)
            {
                ActionOnUnit?.Invoke(clickedOn);
            }
        }

        private void SelectPerformed(InputAction.CallbackContext obj)
        {
            var clickedOn = GetClickedUnit();
            if (clickedOn != null)
            {
                SelectOnUnit?.Invoke(clickedOn);
            }
        }

        private Unit GetClickedUnit()
        {
            var mousePosition = playerInput.actions["Mouse Position"].ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMaskUnit))
            {
                return hitInfo.collider.gameObject.GetComponent<Unit>();
            }

            return null;
        }
    }
}
