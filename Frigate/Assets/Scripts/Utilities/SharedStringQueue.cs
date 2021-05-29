using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [CreateAssetMenu(fileName = nameof(SharedStringQueue), menuName = "CrossSceneObjects/" + nameof(SharedStringQueue))]
    public class SharedStringQueue : ScriptableObject
    {
        private readonly Queue<string> _queue = new Queue<string>();

#if UNITY_EDITOR
        public IReadOnlyCollection<string> InternalCollection => _queue;
#endif

        public void Enqueue(string str)
        {
            _queue.Enqueue(str);
        }

        public bool TryDequeue(out string str)
        {
            if (_queue.Count == 0)
            {
                str = null;
                return false;
            }

            str = _queue.Dequeue();
            return true;
        }

        void OnDisable()
        {
            if (_queue.Count > 0)
            {
                Debug.LogWarning($"{_queue.Count} strings will be discarded.");
            }

            _queue.Clear();
        }
    }
}