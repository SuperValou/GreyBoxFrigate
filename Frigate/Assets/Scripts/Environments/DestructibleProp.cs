using Assets.Scripts.Damages;
using UnityEngine;

namespace Assets.Scripts.Environments
{
    public class DestructibleProp : Damageable
    {
        public ParticleSystem explosionEmitter;

        protected override void OnDamage(VulnerableCollider hitCollider, DamageData damageData, MonoBehaviour damager)
        {
            // play sound maybe
        }

        protected override void OnDeath()
        {
            explosionEmitter.Play(withChildren: true);
            Destroy(this.gameObject);
        }
    }
}