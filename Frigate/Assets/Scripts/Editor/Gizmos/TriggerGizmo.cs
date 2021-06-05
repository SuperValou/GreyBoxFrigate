using Assets.Scripts.Environments;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos
{
    public static class TriggerGizmo
    {
        private static readonly Color Color = new Color(r:0, g:1, b:0, a:0.1f);

        [DrawGizmo(GizmoType.NonSelected)]
        private static void DrawGizmo(Trigger trigger, GizmoType gizmoType)
        {
            UnityEngine.Gizmos.color = Color;

            var col = trigger.GetComponent<Collider>();
            if (col is BoxCollider box)
            {
                UnityEngine.Gizmos.DrawCube(box.transform.position, box.size);
                return;
            }

            if (col is SphereCollider sphere)
            {
                UnityEngine.Gizmos.DrawSphere(sphere.transform.position, sphere.radius);
                return;
            }

            UnityEngine.Gizmos.DrawWireCube(col.transform.position, col.bounds.size);
        }
    }
}