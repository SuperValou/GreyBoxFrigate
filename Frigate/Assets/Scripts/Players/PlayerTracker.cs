using UnityEngine;

namespace Assets.Scripts.Players
{
    public class PlayerTracker : MonoBehaviour
    {
        // -- Editor

        [Header("Parts")]
        public Player player;
        public PlayerSharedData playerSharedData;

        // -- Class

        void Awake()
        {
            playerSharedData.Position = player.transform.position;
            playerSharedData.Rotation = player.transform.rotation;
        }

        void Update()
        {
            playerSharedData.Position = player.transform.position;
            playerSharedData.Rotation = player.transform.rotation;
        }
    }
}