using Assets.Scripts.Environments;
using UnityEditor;

namespace Assets.Scripts.Editor.Gizmos.Types
{
    public class CounterGizmo : ObjectGizmo<Counter>
    {
        private const string IconName = "counter.png";
        
        public override void DrawGizmo(Counter counter, GizmoType gizmoType)
        {
            UnityEngine.Gizmos.DrawIcon(counter.transform.position, IconName, allowScaling: true);

            base.DrawGizmo(counter, gizmoType);
        }
    }
}