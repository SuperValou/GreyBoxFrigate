using Assets.Scripts.Environments;
using Assets.Scripts.Players.LockOns;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos
{
    public static class LockOnTargetGizmo
    {
        private const string IconName = "target.png";

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        private static void DrawGizmo(LockOnTarget target, GizmoType gizmoType)
        {
            UnityEngine.Gizmos.DrawIcon(target.transform.position, IconName, allowScaling: true);
        }
    }
}