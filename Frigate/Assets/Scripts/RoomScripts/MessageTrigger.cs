using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.RoomScripts
{
    public class MessageTrigger : MonoBehaviour
    {
        // -- Editor
        [Header("Values")] [TextArea(minLines: 5, maxLines: 20)]
        public string messageToDisplay = string.Empty;

        public string triggeringTag = "Player";

        [Header("References")]
        [Tooltip(nameof(ISharedValueIn<string>))]
        public Object sharedMessage;

        // -- Class

        private ISharedValueIn<string> _message;
        
        void Start()
        {
            _message = (ISharedValueIn<string>) sharedMessage;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag != triggeringTag)
            {
                return;
            }

            _message.Set(messageToDisplay);
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag != triggeringTag)
            {
                return;
            }

            _message.Reset();
        }
    }
}