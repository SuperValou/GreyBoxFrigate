using Assets.Scripts.PersistentData;
using UnityEngine;

namespace Assets.Scripts.Players.LockOns
{
    public class LockOnTarget : MonoBehaviour
    {
        // -- Editor

        public LockOnTargetSet lockOnSet;

        // -- Class

        void Start()
        {
            lockOnSet.Add(this);
        }

        void OnDestroy()
        {
            lockOnSet.Remove(this);
        }
    }
}