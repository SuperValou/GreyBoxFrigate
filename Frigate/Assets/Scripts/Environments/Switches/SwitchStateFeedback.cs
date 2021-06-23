using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;

namespace Assets.Scripts.Environments.Switches
{
    public class SwitchStateFeedback : MonoBehaviour
    {
        // -- Editor

        [Header("Values")] public Color enabledColor = Color.green;
        public Color disabledColor = Color.red;

        [Header("Parts")] public MeshRenderer colorRenderer;

        // -- Class

        [SerializeField]
        private PersistentBool _state = default;

        void Start()
        {
            _state.ValueChanged += OnValueChanged;
            OnValueChanged(_state.Value);
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