using Assets.Scripts.Damages;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Player : Damageable
    {
        // -- Class

        public FirstPersonController FirstPersonController { get; private set; }
        public WeaponManager WeaponManager { get; private set; }


        void Start()
        {
            FirstPersonController = this.GetOrThrow<FirstPersonController>();
            WeaponManager = this.GetOrThrow<WeaponManager>();
        }

        protected override void OnDamage(VulnerableCollider hitCollider, DamageData damageData, MonoBehaviour damager)
        {
            // TODO: say ouch
        }

        protected override void OnDeath()
        {
            // TODO: ooof
        }
    }
}