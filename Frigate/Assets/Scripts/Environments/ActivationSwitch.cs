using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environments
{
    public class ActivationSwitch : MonoBehaviour
    {
        // -- Editor

        [SerializeField]
        private bool _state = false;

        public UnityEvent onTurnedOn;
        public UnityEvent onTurnedOff;
        public UnityEvent onFlipped;

        // -- Class

        public bool IsTurnedOn => _state;
        public bool IsTurnedOff => !_state;
        
        public void Flip()
        {
            _state = !_state;
            onFlipped.Invoke();

            if (_state)
            {
                onTurnedOn.Invoke();
            }
            else
            {
                onTurnedOff.Invoke();
            }
        }
    }
}