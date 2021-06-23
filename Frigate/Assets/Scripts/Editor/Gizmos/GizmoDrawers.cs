using Assets.Scripts.Editor.Gizmos.Types;
using Assets.Scripts.Environments;
using Assets.Scripts.Environments.Switches;
using Assets.Scripts.Players.LockOns;
using UnityEditor;

namespace Assets.Scripts.Editor.Gizmos
{
    public static class GizmoDrawers
    {
        private static readonly CounterGizmo _counter;
        private static readonly LockOnTargetGizmo _lockOn;
        private static readonly OneWaySwitchGizmo _oneWaySwitch;
        private static readonly ToggleSwitchGizmo _toggleSwitch;
        private static readonly TriggerGizmo _trigger;

        static GizmoDrawers()
        {
            _counter = new CounterGizmo();
            _lockOn = new LockOnTargetGizmo();
            _oneWaySwitch = new OneWaySwitchGizmo();
            _toggleSwitch = new ToggleSwitchGizmo();
            _trigger = new TriggerGizmo();
        }

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(Counter counter, GizmoType gizmoType)
        {
            _counter.DrawGizmo(counter, gizmoType);
        }

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        private static void DrawGizmo(LockOnTarget target, GizmoType gizmoType)
        {
            _lockOn.DrawGizmo(target, gizmoType);
        }

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(OneWaySwitch oneWaySwitch, GizmoType gizmoType)
        {
            _oneWaySwitch.DrawGizmo(oneWaySwitch, gizmoType);
        }

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(ToggleSwitch toggleSwitch, GizmoType gizmoType)
        {
            _toggleSwitch.DrawGizmo(toggleSwitch, gizmoType);
        }

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        static void DrawGizmo(Trigger trigger, GizmoType gizmoType)
        {
            _trigger.DrawGizmo(trigger, gizmoType);
        }
    }
}