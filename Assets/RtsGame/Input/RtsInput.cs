using System.Collections.Generic;
using RtsGame.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RtsGame.Input
{
    public class RtsInput : MonoBehaviour
    {
        [SerializeField] private List<Unit> selected;
        [SerializeField] private Unit target;
        [SerializeField] private PlayerInput playerInput;
        
        void Awake()
        {
            playerInput.actions["Click"].performed += ClickPerformed;
        }

        private void ClickPerformed(InputAction.CallbackContext obj)
        {
            foreach (var unit in selected)
            {
                unit.DealDamage(target);
            }
        }
    }
}