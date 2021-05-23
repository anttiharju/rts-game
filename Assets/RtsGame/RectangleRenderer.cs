using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RtsGame
{
    public class RectangleRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lr;
        [SerializeField] private float y;

        void Start()
        {
            lr.enabled = false;
            lr.positionCount = 5;
        }

        public void Show()
        {
            lr.enabled = true;
        }

        public void Hide()
        {
            lr.enabled = false;
        }

        public void SetCorners(Vector3 lowerLeft, Vector3 upperRight)
        {
            lowerLeft.y = y;
            upperRight.y = y;
            lr.SetPosition(0, lowerLeft);
            lr.SetPosition(1, new Vector3(lowerLeft.x, y, upperRight.z));
            lr.SetPosition(2, upperRight);
            lr.SetPosition(3, new Vector3(upperRight.x, y, lowerLeft.z));
            lr.SetPosition(4, lowerLeft);
        }
    }
}
