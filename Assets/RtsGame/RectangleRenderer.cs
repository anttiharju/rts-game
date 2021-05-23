using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RtsGame
{
    public class RectangleRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lr;
        [SerializeField] private float y;
        [SerializeField] private Vector3 lowerLeft;
        [SerializeField] private Vector3 upperRight;

        void Start()
        {
            lr.positionCount = 5;
        }

        void Update()
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
