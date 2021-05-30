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

        [Header("References")]
        public PlayerSharedData playerSharedData;
        public SharedString sharedMessage;

        // -- Class

        IEnumerator Start()
        {
            var playerInitialPosition = playerSharedData.Position;
            var playerInitialRotation = playerSharedData.Rotation;

            sharedMessage.Set("Move with <size=120%><anim:blink>ZQSD</anim></size>.");
            while (Vector3.Distance(playerInitialPosition, playerSharedData.Position) < minPlayerMovement)
            {
                yield return null;
            }

            sharedMessage.Set("Look around with <size=150%><anim:wave>\u243E</anim></size>.");
            // TODO: while not enough rotated
            yield return new WaitForSeconds(5);

            sharedMessage.Reset();
        }
    }
}