using Assets.Scripts.LoadingSystems.PersistentVariables;
using Assets.Scripts.TypewriterEffects;
using UnityEngine;

namespace Assets.Scripts.Huds
{
    public class MessageDisplay : MonoBehaviour
    {
        // -- Editor

        [Header("Parts")]
        public TypewriterAnimator typewriterAnimator;

        [Header("References")]
        public PersistentString message;

        // -- Class

        void Start()
        {
            typewriterAnimator.Animate(message.Value);

            message.ValueChanged += OnMessageChanged;
        }

        private void OnMessageChanged(string newMessage)
        {
            typewriterAnimator.Animate(newMessage);
        }
    }
}