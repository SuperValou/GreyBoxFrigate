using Assets.Scripts.Environments;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos
{
    public static class ToggleSwitchGizmo
    {
        private const string OnIconName = "toggle_on.png";
        private const string OffIconName = "toggle_off.png";

        private static readonly Vector3 IconOffset = Vector3.up;

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        private static void DrawGizmo(ToggleSwitch toggleSwitch, GizmoType gizmoType)
        {
            var position = toggleSwitch.transform.position + IconOffset;
            string iconName = toggleSwitch.IsTurnedOn ? OnIconName : OffIconName;
            UnityEngine.Gizmos.DrawIcon(position, iconName, allowScaling: true);

            UnityEventLinkGizmo.DrawGizmo(toggleSwitch.onTurnedOn, gizmoType);
        }
    }
}