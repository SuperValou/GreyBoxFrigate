using UnityEngine;

namespace Assets.Scripts.Players
{
    public class AimAssist : MonoBehaviour
    {
        // -- Editor

        public Camera eye;
        public Transform arm;

        public float maxDistance = 100;

        public LayerMask applicableLayers;

        // -- Class

        private readonly Vector3 _viewportPoint = new Vector3(0.5f, 0.5f, 0);

        void Update()
        {
            Ray ray = eye.ViewportPointToRay(_viewportPoint);
            //Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.blue);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, applicableLayers))
            {
                arm.LookAt(raycastHit.point);
                //Debug.DrawLine(arm.position, raycastHit.point, Color.red);
                //if (Input.GetKeyDown(KeyCode.K))
                //{
                //    Debug.LogWarning(raycastHit.transform.name);
                //}
            }
            else
            {
                arm.LookAt(arm.position + eye.transform.forward);
                //Debug.DrawRay(arm.position, maxDistance * arm.forward, Color.yellow);
            }
        }
    }
}