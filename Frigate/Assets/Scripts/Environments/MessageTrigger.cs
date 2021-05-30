using Assets.Scripts.CrossSceneData;
using UnityEngine;

namespace Assets.Scripts.Environments
{
    public class MessageTrigger : MonoBehaviour
    {
        // -- Editor
        [Header("Values")] [TextArea(minLines: 5, maxLines: 20)]
        public string messageToDisplay = string.Empty;

        public string triggeringTag = "Player";

        [Header("References")]
        public SharedString sharedMessage;

        // -- Class

        void OnTriggerEnter(Collider col)
        {
            if (col.tag != triggeringTag)
            {
                return;
            }

            sharedMessage.Set(messageToDisplay);
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag != triggeringTag)
            {
                return;
            }

            sharedMessage.Reset();
        }
    }
}