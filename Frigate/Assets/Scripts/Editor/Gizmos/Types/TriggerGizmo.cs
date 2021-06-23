using Assets.Scripts.Environments;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos.Types
{
    public class TriggerGizmo : ObjectGizmo<Trigger>
    {
        private readonly Color Color = new Color(r:0, g:1, b:0, a:0.1f);

        public override void DrawGizmo(Trigger trigger, GizmoType gizmoType)
        {
            if (trigger == null)
            {
                return;
            }

            UnityEngine.Gizmos.color = Color;

            var col = trigger.GetComponent<Collider>();
            if (col is BoxCollider box)
            {
                UnityEngine.Gizmos.DrawCube(box.transform.position, box.size);
            }
            else if (col is SphereCollider sphere)
            {
                UnityEngine.Gizmos.DrawSphere(sphere.transform.position, sphere.radius);
                return;
            }
            else
            {
                UnityEngine.Gizmos.DrawWireCube(col.transform.position, col.bounds.size);
            }

            base.DrawGizmo(trigger, gizmoType);
        }
    }
}