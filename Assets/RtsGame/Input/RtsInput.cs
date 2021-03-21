using System;
using System.Collections.Generic;
using RtsGame.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.Input
{
    public class RtsInput : MonoBehaviour
    {
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;
        
        [SerializeField] private PlayerInput playerInput;

        private int layerMaskUnit;

        void Awake()
        {
            playerInput.actions["Action"].performed += ActionPerformed;
            playerInput.actions["Select"].performed += SelectPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
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