using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Editor.Gizmos.Types
{
    public class ObjectGizmo<TMonoBehaviour>
        where TMonoBehaviour : MonoBehaviour
    {
        private const float MaxSquaredRenderDistance = 800;
        private const float MinSquaredDistance = 1;
        private const float StackedLabelOffset = 0.25f;

        private readonly Color _selectedRayColor = new Color(r: 1f, g: 0.8f, b: 0.8f, a: 1f);
        private readonly Color _passiveRayColor = new Color(r: 0.7f, g: 0.7f, b: 0.7f, a: 0.7f);

        private readonly ICollection<FieldInfo> _unityEventFields;

        private readonly Dictionary<Vector3, string> _drawnLabels = new Dictionary<Vector3, string>();

        protected ObjectGizmo()
        {
            var type = typeof(TMonoBehaviour);
            var fields = type.GetFields();
            _unityEventFields = fields.Where(f => f.FieldType == typeof(UnityEvent)).ToList();
        }

        public virtual void DrawGizmo(TMonoBehaviour gameObject, GizmoType gizmoType)
        {
            var camPosition = SceneView.lastActiveSceneView.camera.transform.position;
            var objectSquaredDistance = gameObject.transform.position - camPosition;
            if (objectSquaredDistance.sqrMagnitude > MaxSquaredRenderDistance)
            {
                // Camera is too far to display any gizmo related to the owner
                return;
            }

            DrawUnityEventLinks(gameObject, gizmoType);
        }

        /// <summary>
        /// Draw a line from the owner to the target with the name of the method.
        /// </summary>
        private void DrawUnityEventLinks(TMonoBehaviour unityEventOwner, GizmoType gizmoType)
        {
            // Set colors
            Color color;
            if (gizmoType.HasFlag(GizmoType.Selected))
            {
                color = _selectedRayColor;
            }
            else
            {
                color = _passiveRayColor;
            }

            UnityEngine.Gizmos.color = color;
            GUIStyle labelStyle = new GUIStyle
            {
                normal =
                {
                    textColor = color
                }
            };

            // Compute positions of line and label
            _drawnLabels.Clear();

            Vector3 sourcePostion = unityEventOwner.transform.position;

            foreach (var unityEventField in _unityEventFields)
            {
                var unityEvent = (UnityEvent) unityEventField.GetValue(unityEventOwner);

                int targetCount = unityEvent.GetPersistentEventCount();

                for (int i = 0; i < targetCount; i++)
                {
                    var targetObject = unityEvent.GetPersistentTarget(i);

                    var methodName = unityEvent.GetPersistentMethodName(i);

                    Vector3 targetPosition;

                    GameObject targetGameObject = targetObject as GameObject;
                    if (targetObject is Component component)
                    {
                        targetGameObject = component.gameObject;
                    }

                    if (targetGameObject != null)
                    {
                        if (targetGameObject == unityEventOwner.gameObject)
                        {
                            // gameObject is calling a method on itself
                            targetPosition = unityEventOwner.transform.position + Vector3.down;
                            DrawLabel(targetPosition, "[itself]", labelStyle, Vector3.down);
                        }
                        else
                        {
                            targetPosition = targetGameObject.transform.position;
                        }
                    }
                    else
                    {
                        // target is some unhandled Unity Object
                        targetPosition = unityEventOwner.transform.position + Vector3.up * 2;
                        string targetName = $"[{targetObject.name} ({targetObject.GetType().Name})]";
                        DrawLabel(targetPosition, targetName, labelStyle, Vector3.up);
                    }

                    UnityEngine.Gizmos.DrawLine(sourcePostion, targetPosition);

                    string label = $"{unityEventField.Name}->{methodName}";
                    Vector3 labelPosition = (sourcePostion + targetPosition) / 2f;
                    DrawLabel(labelPosition, label, labelStyle, Vector3.up);
                }
            }
        }

        private void DrawLabel(Vector3 labelPosition, string label, GUIStyle style, Vector3 stackDirection)
        {
            if (_drawnLabels.ContainsKey(labelPosition))
            {
                if (_drawnLabels[labelPosition] == label)
                {
                    // do not draw same label at the same position twice
                    return;
                }

                // offset the position to avoid overlapping an existing label
                labelPosition = labelPosition + stackDirection.normalized * StackedLabelOffset;
                DrawLabel(labelPosition, label, style, stackDirection);
                return;
            }

            _drawnLabels[labelPosition] = label;
            Handles.Label(labelPosition, label, style);
        }
    }
}