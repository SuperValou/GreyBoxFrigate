using Assets.Scripts.Players.LockOns;
using UnityEditor;

namespace Assets.Scripts.Editor.Gizmos.Types
{
    public class LockOnTargetGizmo : ObjectGizmo<LockOnTarget>
    {
        private const string IconName = "target.png";
        
        public override void DrawGizmo(LockOnTarget target, GizmoType gizmoType)
        {
            if (target == null)
            {
                return;
            }

            UnityEngine.Gizmos.DrawIcon(target.transform.position, IconName, allowScaling: true);

            base.DrawGizmo(target, gizmoType);
        }
    }
}