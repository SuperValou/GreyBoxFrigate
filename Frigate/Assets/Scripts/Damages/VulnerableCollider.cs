using System;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Damages
{
    public class VulnerableCollider : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        public float damageMultiplier = 1f; // TODO: encapsulate data into scriptable object
        
        // -- Class
        
        public Collider Collider { get; private set; }
        
        public event Action<VulnerableCollider, DamageData, MonoBehaviour> Hit;

        void Start()
        {
            Collider = this.GetOrThrow<Collider>();
        }
        
        public void OnHit(DamageData damageData, MonoBehaviour damager)
        {
            float amountResult = damageMultiplier * damageData.Amount;
            var damageResult = new DamageData(amountResult);

            Hit.SafeInvoke(this, damageResult, damager);
        }

        void OnDestroy()
        {
            // clear subscribers
            Hit = null;
        }
    }
}