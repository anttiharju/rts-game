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
        private readonly int layerMaskGround;

        private RectangleRenderer rectangleRenderer;
        private Vector3 dragStartPosition;

        public RtsInput(UnityInputWrapper unityInputWrapper, RectangleRenderer rectangleRenderer)
        {
            this.rectangleRenderer = rectangleRenderer;
            layerMaskUnit = 1 << LayerMask.NameToLayer("Unit");
            layerMaskGround = 1 << LayerMask.NameToLayer("Ground");

            unityInputWrapper.RightMouseButtonClicked += OnRightMouseButtonClicked;
            unityInputWrapper.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
            unityInputWrapper.LeftMouseButtonDragBegin += OnLeftMouseButtonDragBegin;
            unityInputWrapper.LeftMouseButtonDragUpdate += OnLeftMouseButtonDragUpdate;
            unityInputWrapper.LeftMouseButtonDragStop += OnLeftMouseButtonDragStop;
        }

        private void OnLeftMouseButtonDragBegin(Vector2 screenPosition)
        {
            dragStartPosition = GetGroundPosition(screenPosition);
            rectangleRenderer.SetCorners(dragStartPosition, dragStartPosition);
            rectangleRenderer.Show();
        }

        private Vector3 GetGroundPosition(Vector2 screenPosition)
        {
            var ray = Camera.main.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMaskGround))
            {
                return hitInfo.point;
            }
            throw new Exception("No ground found!");
        }

        private void OnLeftMouseButtonDragUpdate(Vector2 screenPosition)
        {
            var dragCurrentPosition = GetGroundPosition(screenPosition);
            rectangleRenderer.SetCorners(dragStartPosition, dragCurrentPosition);
        }

        private void OnLeftMouseButtonDragStop(Vector2 screenPosition)
        {
            rectangleRenderer.Hide();
        }

        private void OnRightMouseButtonClicked(Vector2 screenPosition)
        {
            var clickedOn = GetClickedUnit(screenPosition);
            if (clickedOn != null)
            {
                ActionOnUnit?.Invoke(clickedOn);
            }
        }

        private void OnLeftMouseButtonClicked(Vector2 screenPosition)
        {
            var clickedOn = GetClickedUnit(screenPosition);
            if (clickedOn != null)
            {
                SelectOnUnit?.Invoke(clickedOn);
            }
        }

        private Unit GetClickedUnit(Vector2 screenPosition)
        {
            if (!(Camera.main is null))
            {
                Ray ray = Camera.main.ScreenPointToRay(screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMaskUnit))
                {
                    return hitInfo.collider.gameObject.GetComponent<Unit>();
                }
            }

            return null;
        }
    }
}
