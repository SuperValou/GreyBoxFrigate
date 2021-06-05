using TMPro;
using UnityEngine;

namespace Assets.Scripts.Environments
{
    public class ToogleSwitchFeedback : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        public Color enabledColor = Color.green;
        public Color disabledColor = Color.red;

        [Header("Parts")]
        public MeshRenderer colorRenderer;

        // -- Class

        public void Init(bool initialState)
        {
            if (initialState)
            {
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }

        public void TurnOn()
        {
            colorRenderer.material.color = enabledColor;
        }

        public void TurnOff()
        {
            colorRenderer.material.color = disabledColor;
        }
    }
}