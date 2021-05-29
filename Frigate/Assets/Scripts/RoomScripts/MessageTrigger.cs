using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.RoomScripts
{
    public class MessageTrigger : MonoBehaviour
    {
        // -- Editor
        [Header("Values")]
        [TextArea(minLines: 5, maxLines: 20)]
        public string messageToDisplay = string.Empty;

        public string triggeringTag = "Player";

        [Header("References")]
        public SharedStringQueue messageQueue;

        // -- Class

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == triggeringTag)
            {
                messageQueue.Enqueue(messageToDisplay);
            }
        }
    }
}