using UnityEngine;

namespace Assets.Scripts.Players
{
    [CreateAssetMenu(fileName = nameof(PlayerSharedData), menuName = "CrossSceneObjects/" + nameof(PlayerSharedData))]
    public class PlayerSharedData : ScriptableObject
    {
        [SerializeField]
        private bool _isInvulnerable;

        [SerializeField]
        private Vector3 _position;

        public bool IsInvulnerable
        {
            get => _isInvulnerable;
            set => _isInvulnerable = value;
        }

        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }
    }
}