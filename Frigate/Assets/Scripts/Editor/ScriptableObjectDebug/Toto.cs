using Assets.Scripts.Utilities;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.ScriptableObjectDebug
{
    [CustomEditor(typeof(SharedStringQueue))]
    public class SharedStringQueueEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SharedStringQueue queue = (SharedStringQueue) target;

            GUILayout.Label($"{queue.InternalCollection.Count} string(s)");
            foreach (var str in queue.InternalCollection)
            {
                GUILayout.Label(str);
            }
        }

    }
}