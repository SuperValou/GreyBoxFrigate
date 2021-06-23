using System;
using Assets.Scripts.Damages;
using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environments.Switches
{
    public class ToggleSwitch : MonoBehaviour
    {
        // -- Editor
        
        [Header("Events")]
        public UnityEvent onTurnedOn;
        public UnityEvent onTurnedOff;
        public UnityEvent onToggle;

        // -- Class

        [Header("Debug")]
        [SerializeField]
        private PersistentBool _state = default ;

        private VulnerableCollider _vulnerableCollider;

        public bool IsTurnedOn => _state.Value;
        public bool IsTurnedOff => !_state.Value;

        void Start()
        {
            _vulnerableCollider = this.GetComponentInChildren<VulnerableCollider>();
            if (_vulnerableCollider == null)
            {
                throw new ArgumentException($"No {nameof(VulnerableCollider)} was found in {this.name} ({this.GetType().Name}). " +
                                            $"It makes it unable to be interacted with. Did you forget to add a {nameof(VulnerableCollider)} to one of its children?");
            }

            _vulnerableCollider.Hit += OnHit;
        }

        public void Toggle()
        {
            _state.Value = !_state.Value;
            onToggle.Invoke();

            if (_state)
            {
                onTurnedOn.Invoke();
            }
            else
            {
                onTurnedOff.Invoke();
            }
        }

        private void OnHit(VulnerableCollider vulnerableCollider, DamageData damageData, MonoBehaviour damager)
        {
            Toggle();
        }

        void OnDestroy()
        {
            if (ReferenceEquals(_vulnerableCollider, null))
            {
                return;
            }

            _vulnerableCollider.Hit -= OnHit;
        }
    }
}