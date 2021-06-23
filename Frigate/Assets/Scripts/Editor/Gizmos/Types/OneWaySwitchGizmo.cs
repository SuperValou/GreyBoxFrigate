using Assets.Scripts.Editor.Gizmos.Types;
using Assets.Scripts.Environments.Switches;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Gizmos
{
    public class OneWaySwitchGizmo : ObjectGizmo<OneWaySwitch>
    {
        private const string OnIconName = "toggle_on.png";
        private const string OffIconName = "toggle_off.png";

        private readonly Vector3 _iconOffset = Vector3.up;

        public override void DrawGizmo(OneWaySwitch oneWaySwitch, GizmoType gizmoType)
        {
            if (oneWaySwitch == null)
            {
                return;
            }

            var position = oneWaySwitch.transform.position + _iconOffset;
            string iconName = oneWaySwitch.IsActivated ? OnIconName : OffIconName;
            UnityEngine.Gizmos.DrawIcon(position, iconName, allowScaling: true);

            base.DrawGizmo(oneWaySwitch, gizmoType);
        }
    }
}