using RtsGame.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.Input
{
    public class UnityRtsInput : RtsInput
    {
        private int layerMaskUnit;
        private PlayerInput playerInput;

        public UnityRtsInput(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            playerInput.actions["Action"].performed += ActionPerformed;
            playerInput.actions["Select"].performed += SelectPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
        }

        private void ActionPerformed(InputAction.CallbackContext obj)
        {
            var clickedOn = GetClickedUnit();
            if (clickedOn != null)
            {
                OnActionOnUnit(clickedOn);
            }
        }

        private void SelectPerformed(InputAction.CallbackContext obj)
        {
            var clickedOn = GetClickedUnit();
            if (clickedOn != null)
            {
                OnSelectOnUnit(clickedOn);
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