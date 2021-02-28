using System;
using System.Collections.Generic;
using RtsGame.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.Input
{
    public class RtsInput : MonoBehaviour
    {
        public event Action<Unit> ClickedOnUnit;
        
        [SerializeField] private PlayerInput playerInput;

        private int layerMaskUnit;

        void Awake()
        {
            playerInput.actions["Click"].performed += ClickPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
        }

        private void ClickPerformed(InputAction.CallbackContext obj)
        {
            var mousePosition = playerInput.actions["Mouse Position"].ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMaskUnit))
            {
                var hitUnit = hitInfo.collider.gameObject.GetComponent<Unit>();
                ClickedOnUnit?.Invoke(hitUnit);
            }
        }
    }
}