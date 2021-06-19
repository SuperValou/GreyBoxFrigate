using Assets.Scripts.LoadingSystems.PersistentVariables;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Environments
{
    public class ToggleSwitchFeedback : MonoBehaviour
    {
        // -- Editor

        [Header("Values")] public Color enabledColor = Color.green;
        public Color disabledColor = Color.red;

        [Header("Parts")] public MeshRenderer colorRenderer;

        // -- Class

        [SerializeField] private PersistentBool _state;

        void Start()
        {
            OnValueChanged(_state.Value);
            _state.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(bool value)
        {
            if (value)
            {
                DisplayOn();
            }
            else
            {
                DisplayOff();
            }
        }

        public void DisplayOn()
        {
            colorRenderer.material.color = enabledColor;
        }

        public void DisplayOff()
        {
            colorRenderer.material.color = disabledColor;
        }

        void OnDestroy()
        {
            _state.ValueChanged -= OnValueChanged;
        }
    }
}