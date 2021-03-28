using System;
using RtsGame.Units;
using UnityEngine;

namespace RtsGame.Input
{
    public abstract class RtsInput : MonoBehaviour
    {
        public event Action<Unit> ActionOnUnit;
        public event Action<Unit> SelectOnUnit;

        protected void OnActionOnUnit(Unit unit)
        {
            ActionOnUnit?.Invoke(unit);
        }
        
        protected void OnSelectOnUnit(Unit unit)
        {
            SelectOnUnit?.Invoke(unit);
        }
    }
}