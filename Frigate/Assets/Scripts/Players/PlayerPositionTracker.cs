using UnityEngine;

namespace Assets.Scripts.Players
{
    public class PlayerPositionTracker : MonoBehaviour
    {
        // -- Editor

        [Header("Parts")]
        public Player player;
        public PlayerSharedData playerSharedData;

        // -- Class

        void Update()
        {
            playerSharedData.Position = player.transform.position;
        }
    }
}