using UnityEngine;

namespace RtsGame.Units
{
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        [SerializeField] private GameObject selectionIndicator;

        private void Awake()
        {
            unit.OnSelectionChanged += ToggleSelectionIndicator;
            selectionIndicator.SetActive(false);
        }

        private void ToggleSelectionIndicator(bool selected)
        {
            selectionIndicator.SetActive(selected);
        }
    }
}
