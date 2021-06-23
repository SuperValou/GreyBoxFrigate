using System;
using Assets.Scripts.Damages;
using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environments
{
    public class ToggleSwitch : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        [Tooltip("Number of times it can be interacted with. Set to zero or less to have no limit.")]
        public int maxInteraction = 0;
        
        [Header("Events")]
        public UnityEvent onTurnedOn;
        public UnityEvent onTurnedOff;
        public UnityEvent onToggle;

        // -- Class

        [Header("Debug")]
        [SerializeField]
        private PersistentBool _state = default ;

        [SerializeField]
        private int _interactionCount = 0;
        
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

            if (maxInteraction <= 0)
            {
                // no interacting limit
                return;
            }

            _interactionCount++;
            if (_interactionCount >= maxInteraction)
            {
                _vulnerableCollider.Hit -= OnHit;
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