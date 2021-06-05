using System;
using Assets.Scripts.Damages;
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
        
        [SerializeField]
        private bool _state = false;

        [Header("Events")]
        public UnityEvent onStart;
        public UnityEvent onTurnedOn;
        public UnityEvent onTurnedOff;
        public UnityEvent onToggle;

        // -- Class

        private bool _hasMaxInteractions;
        private VulnerableCollider _vulnerableCollider;

        public bool IsTurnedOn => _state;
        public bool IsTurnedOff => !_state;

        void Start()
        {
            _hasMaxInteractions = maxInteraction > 0;

            _vulnerableCollider = this.GetComponentInChildren<VulnerableCollider>();
            if (_vulnerableCollider == null)
            {
                throw new ArgumentException($"No {nameof(VulnerableCollider)} was found in {this.name} ({this.GetType().Name}). " +
                                            $"It makes it unable to be interacted with. Did you forget to add a {nameof(VulnerableCollider)} to one of its children?");
            }

            _vulnerableCollider.Hit += OnHit;

            onStart.Invoke();
        }

        public void Toggle()
        {
            _state = !_state;
            onToggle.Invoke();

            if (_state)
            {
                onTurnedOn.Invoke();
            }
            else
            {
                onTurnedOff.Invoke();
            }

            if (!_hasMaxInteractions)
            {
                return;
            }

            maxInteraction--;
            if (maxInteraction <= 0)
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