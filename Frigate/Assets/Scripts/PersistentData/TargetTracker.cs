using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;

namespace Assets.Scripts.PersistentData
{
    public class TargetTracker : MonoBehaviour
    {
        // -- Editor

        [Header("Parts")]
        public PersistentVector3 position;
        public PersistentQuaternion rotation;

        [Header("References")]
        public Transform target;

        // -- Class

        void Awake()
        {
            Update();
        }

        void Update()
        {
            position.Value = target.position;
            rotation.Value = target.rotation;
        }
    }
}