using Assets.Scripts.CrossSceneData;
using UnityEngine;

namespace Assets.Scripts.Players.LockOns
{
    public class LockOnTarget : MonoBehaviour
    {
        // -- Editor

        public LockOnTargetSharedSet lockOnSet;

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