using Assets.Scripts.Environments;
using Assets.Scripts.Players.LockOns;
using UnityEditor;

namespace Assets.Scripts.Editor.Gizmos
{
    public class CounterGizmo
    {
        private const string IconName = "counter.png";

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        private static void DrawTriggerGizmo(Counter counter, GizmoType gizmoType)
        {
            UnityEngine.Gizmos.DrawIcon(counter.transform.position, IconName, allowScaling: true);
        }
    }
}