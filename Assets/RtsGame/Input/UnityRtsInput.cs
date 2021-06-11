using System;
using RtsGame.Units;
using UnityEngine;
using Utilities;

namespace RtsGame.Input
{
    public class RtsInput : IRtsInput
    {
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;

        private readonly int layerMaskUnit;

        private UnityInputWrapper unityInputWrapper;
        private RectangleRenderer rectangleRenderer;

        public RtsInput(UnityInputWrapper unityInputWrapper, RectangleRenderer rectangleRenderer)
        {
            this.unityInputWrapper = unityInputWrapper;
            unityInputWrapper.RightMouseButtonClicked += RightMouseButtonClickedPerformed;
            unityInputWrapper.LeftMouseButtonClicked += LeftMouseButtonClickedPerformed;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
            this.rectangleRenderer = rectangleRenderer;
        }

        private void RightMouseButtonClickedPerformed(Vector2 screenPosition)
        {
            var clickedOn = GetClickedUnit(screenPosition);
            if (clickedOn != null)
            {
                ActionOnUnit?.Invoke(clickedOn);
            }
        }

        private void LeftMouseButtonClickedPerformed(Vector2 screenPosition)
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
