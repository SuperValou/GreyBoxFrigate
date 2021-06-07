using Assets.Scripts.Environments;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos.Types
{
    public class ToggleSwitchGizmo : ObjectGizmo<ToggleSwitch>
    {
        private const string OnIconName = "toggle_on.png";
        private const string OffIconName = "toggle_off.png";

        private readonly Vector3 _iconOffset = Vector3.up;

        public override void DrawGizmo(ToggleSwitch toggleSwitch, GizmoType gizmoType)
        {
            var position = toggleSwitch.transform.position + _iconOffset;
            string iconName = toggleSwitch.IsTurnedOn ? OnIconName : OffIconName;
            UnityEngine.Gizmos.DrawIcon(position, iconName, allowScaling: true);

            base.DrawGizmo(toggleSwitch, gizmoType);
        }
    }
}