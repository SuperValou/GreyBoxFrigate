using System.Collections;
using Assets.Scripts.CrossSceneData;
using Assets.Scripts.Players;
using UnityEngine;

namespace Assets.Scripts.SceneScripts
{
    public class TutoRoomScript : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        [Tooltip("Minimal movement the player has to make to consider she knows how to move (meters).")]
        public float minPlayerMovement = 1;

        [Tooltip("Minimal movement the player has to make to consider she knows how to look around (degrees).")]
        public float minPlayerRotation = 45;

        [TextArea(minLines:5, maxLines:20)]
        public string movementText = "Move.";

        [TextArea(minLines: 5, maxLines: 20)]
        public string lookAroundText = "Look around.";

        [Header("References")]
        public PlayerSharedData playerSharedData;
        public SharedString sharedMessage;

        // -- Class

        IEnumerator Start()
        {
            var playerInitialPosition = playerSharedData.Position;
            var playerInitialRotation = playerSharedData.Rotation;

            sharedMessage.Set(movementText);
            while (Vector3.Distance(playerInitialPosition, playerSharedData.Position) < minPlayerMovement)
            {
                yield return null;
            }

            sharedMessage.Set(lookAroundText);
            while (Quaternion.Angle(playerInitialRotation, playerSharedData.Rotation) < minPlayerRotation)
            {
                yield return null;
            }

            if (sharedMessage.Value == lookAroundText)
            {
                sharedMessage.Reset();
            }
        }
    }
}