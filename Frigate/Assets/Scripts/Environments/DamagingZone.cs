using System;
using System.Collections.Generic;
using Assets.Scripts.Damages;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Environments
{
    public class DamagingZone : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        public float damagePerSecond;

        // -- Class

        private readonly List<VulnerableCollider> _vulnerableColliders = new List<VulnerableCollider>();

        void Start()
        {
            var col = this.GetOrThrow<Collider>();
            if (!col.isTrigger)
            {
                throw new ArgumentException($"Collider of {this.name} ({this.GetType().Name}) is not a Trigger.");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            var vulnerableCollider = other?.GetComponent<VulnerableCollider>();
            if (vulnerableCollider == null)
            {
                return;
            }

            _vulnerableColliders.Add(vulnerableCollider);
        }

        void OnTriggerExit(Collider other)
        {
            var vulnerableCollider = other?.GetComponent<VulnerableCollider>();
            if (vulnerableCollider == null)
            {
                return;
            }

            _vulnerableColliders.Remove(vulnerableCollider);
        }

        void Update()
        {
            for (int i = _vulnerableColliders.Count - 1; i >= 0; i--)
            {
                VulnerableCollider vulnerableCollider = _vulnerableColliders[i];
                if (vulnerableCollider?.gameObject == null)
                {
                    _vulnerableColliders.Remove(vulnerableCollider);
                    continue;
                }
            
                float damages = damagePerSecond * Time.deltaTime;
                var damageData = new DamageData(damages);
                vulnerableCollider.OnHit(damageData, damager: this);
            }
        }
    }
}