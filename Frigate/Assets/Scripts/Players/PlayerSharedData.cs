using UnityEngine;

namespace Assets.Scripts.Players
{
    [CreateAssetMenu(fileName = nameof(PlayerSharedData), menuName = "CrossSceneObjects/" + nameof(PlayerSharedData))]
    public class PlayerSharedData : ScriptableObject
    {
        [SerializeField]
        private Vector3 _position;

        [SerializeField]
        private Quaternion _rotation;

        [SerializeField]
        private bool _isInvulnerable;

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        public Quaternion Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public bool IsInvulnerable
        {
            get => _isInvulnerable;
            set => _isInvulnerable = value;
        }
    }
}