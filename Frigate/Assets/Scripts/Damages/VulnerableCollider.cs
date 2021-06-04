using System;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Damages
{
    public class VulnerableCollider : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        public float damageMultiplier = 1f;

        [Header("Parts")]
        public Damageable parentDamageable;
        
        // -- Class
        
        public Collider Collider { get; private set; }
        
        void Start()
        {
            Collider = this.GetOrThrow<Collider>();
            if (parentDamageable == null)
            {
                throw new ArgumentException($"{nameof(parentDamageable)} is null. Damage messages will be lost.");
            }
        }
        
        public void OnHit(DamageData damageData, MonoBehaviour damager)
        {
            float amountResult = damageMultiplier * damageData.Amount;
            var damageResult = new DamageData(amountResult);

            parentDamageable.TakeDamage(vulnerableCollider:this, damageResult, damager);
        }
    }
}