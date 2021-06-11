using System;
using RtsGame.Units;
using UnityEngine;

namespace RtsGame.Input
{
    public class UnityRtsInput : IRtsInput
    {
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;

        private int layerMaskUnit;
        private RtsInput input;
        private RectangleRenderer rectangleRenderer;

        public UnityRtsInput(RtsInput input, RectangleRenderer rectangleRenderer)
        {
            this.input = input;
            input.Action += ActionPerformed;
            input.Select += SelectPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
            this.rectangleRenderer = rectangleRenderer;
        }

        private void ActionPerformed(Vector2 screenPosition)
        {
            var clickedOn = GetClickedUnit(screenPosition);
            if (clickedOn != null)
            {
                ActionOnUnit?.Invoke(clickedOn);
            }
        }

        private void SelectPerformed(Vector2 screenPosition)
        {
            var clickedOn = GetClickedUnit(screenPosition);
            if (clickedOn != null)
            {
                SelectOnUnit?.Invoke(clickedOn);
            }
        }

        private Unit GetClickedUnit(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMaskUnit))
            {
                return hitInfo.collider.gameObject.GetComponent<Unit>();
            }

            return null;
        }
    }
}
