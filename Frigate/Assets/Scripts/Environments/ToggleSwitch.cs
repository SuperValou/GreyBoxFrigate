using Assets.Scripts.Damages;
using Assets.Scripts.Utilities;
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
            _vulnerableCollider = this.GetOrThrow<VulnerableCollider>();
            _vulnerableCollider.Hit += OnHit;
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