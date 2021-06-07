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
        private const float MaxSquaredRenderDistance = 1000;
        private const float MinSquaredDistance = 1;
        private const float StackedLabelOffset = 0.25f;

        private readonly Color _selectedRayColor = new Color(r: 1f, g: 0.8f, b: 0.8f, a: 1f);
        private readonly Color _passiveRayColor = new Color(r: 0.7f, g: 0.7f, b: 0.7f, a: 0.7f);

        private readonly ICollection<FieldInfo> _unityEventFields;

        protected ObjectGizmo()
        {
            var type = typeof(TMonoBehaviour);
            var fields = type.GetFields();
            _unityEventFields = fields.Where(f => f.FieldType == typeof(UnityEvent)).ToList();
        }

        public virtual void DrawGizmo(TMonoBehaviour unityEventOwner, GizmoType gizmoType)
        {
            var camPosition = SceneView.lastActiveSceneView.camera.transform.position;
            var objectSquaredDistance = unityEventOwner.transform.position - camPosition;
            if (objectSquaredDistance.sqrMagnitude > MaxSquaredRenderDistance)
            {
                return;
            }

            // Unity event links
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

            Vector3 sourcePostion = unityEventOwner.transform.position;

            foreach (var unityEventField in _unityEventFields)
            {
                var unityEvent = (UnityEvent) unityEventField.GetValue(unityEventOwner);

                int count = unityEvent.GetPersistentEventCount();

                for (int i = 0; i < count; i++)
                {
                    var obj = unityEvent.GetPersistentTarget(i);
                    var methodName = unityEvent.GetPersistentMethodName(i);

                    if (obj is Component component)
                    {
                        Vector3 targetPosition;
                        if (component.gameObject == unityEventOwner.gameObject)
                        {
                            targetPosition = unityEventOwner.transform.position - Vector3.up;
                            Handles.Label(targetPosition, "(itself)", labelStyle);
                        }
                        else
                        {
                            targetPosition = component.transform.position;
                            if ((targetPosition - sourcePostion).sqrMagnitude < MinSquaredDistance)
                            {
                                targetPosition = sourcePostion + Vector3.up + Vector3.right;
                            }
                        }

                        UnityEngine.Gizmos.DrawLine(sourcePostion, targetPosition);

                        string label = $"{unityEventField.Name}->{methodName}";
                        Vector3 labelPosition = (sourcePostion + targetPosition) / 2f + (i * StackedLabelOffset) * Vector3.down;
                        Handles.Label(labelPosition, label, labelStyle);
                    }
                    else
                    {
                        // TODO
                    }
                }
            }
        }
    }
}