using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environments
{
    public class Counter : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        [Tooltip("Count to reach before raising the event.")]
        public int countToReach;

        [Tooltip("Can the counter be changed once the it reaches its target value?")]
        public bool lockWhenReached = true;
        
        [Header("Events")]
        public UnityEvent onCountReached;

        // -- Class

        [Header("Debug")]
        [SerializeField]
        private int _currentCount = 0;

        private bool _locked;

        public void Increment()
        {
            if (_locked)
            {
                return;
            }

            _currentCount++;
            Check();
        }

        public void Decrement()
        {
            if (_locked)
            {
                return;
            }

            _currentCount--;
            Check();
        }

        private void Check()
        {
            if (_currentCount != countToReach)
            {
                return;
            }

            if (lockWhenReached)
            {
                _locked = true;
            }

            onCountReached.Invoke();
        }
    }
}