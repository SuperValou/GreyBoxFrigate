using System;
using Assets.Scripts.Damages;
using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environments.Switches
{
    public class OneWaySwitch : MonoBehaviour
    {
        // -- Editor

        [Header("Events")]
        public UnityEvent onActivated;

        // -- Class

        [Header("Debug")]
        [SerializeField]
        private PersistentBool _state = default;

        private VulnerableCollider _vulnerableCollider;

        public bool IsActivated => _state.Value;

        void Start()
        {
            _vulnerableCollider = this.GetComponentInChildren<VulnerableCollider>();
            if (_vulnerableCollider == null)
            {
                throw new ArgumentException($"No {nameof(VulnerableCollider)} was found in {this.name} ({this.GetType().Name}). " +
                                            $"It makes it unable to be interacted with. Did you forget to add a {nameof(VulnerableCollider)} to one of its children?");
            }

            if (_state.Value)
            {
                // switch is already activated
                return;
            }

            _vulnerableCollider.Hit += OnHit;
        }

        public void Activate()
        {
            _state.Value = true;
            _vulnerableCollider.Hit -= OnHit;
            onActivated.Invoke();
        }

        private void OnHit(VulnerableCollider vulnerableCollider, DamageData damageData, MonoBehaviour damager)
        {
            Activate();
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