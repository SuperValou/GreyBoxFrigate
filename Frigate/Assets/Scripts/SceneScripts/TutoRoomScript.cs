using System.Collections;
using Assets.Scripts.LoadingSystems.PersistentVariables;
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
        public PersistentVector3 playerPosition;
        public PersistentQuaternion playerRotation;
        public PersistentString hudMessage;

        // -- Class

        IEnumerator Start()
        {
            var playerInitialPosition = playerPosition.Value;
            var playerInitialRotation = playerRotation.Value;

            hudMessage.Value = lookAroundText;
            while (Quaternion.Angle(playerInitialRotation, playerRotation.Value) < minPlayerRotation)
            {
                yield return null;
            }

            hudMessage.Value = movementText;
            while (Vector3.Distance(playerInitialPosition, playerPosition.Value) < minPlayerMovement)
            {
                yield return null;
            }

            if (hudMessage.Value == movementText)
            {
                hudMessage.Value = string.Empty;
            }
        }
    }
}