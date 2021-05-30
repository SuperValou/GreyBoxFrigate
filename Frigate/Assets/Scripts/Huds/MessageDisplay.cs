using System;
using System.Collections;
using Assets.Scripts.TypewriterEffects;
using Assets.Scripts.TypewriterEffects.Notifiables;
using Assets.Scripts.Utilities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Huds
{
    public class MessageDisplay : MonoBehaviour
    {
        // -- Editor

        [Header("Parts")]
        public TypewriterAnimator typewriterAnimator;

        [Header("References")]
        [Tooltip(nameof(ISharedValueOut<string>))]
        public Object message;

        // -- Class

        private ISharedValueOut<string> _message;
        
        void Start()
        {
            _message = (ISharedValueOut<string>) message;
            typewriterAnimator.Animate(_message.Value);

            _message.ValueChanged += OnMessageChanged;
        }

        private void OnMessageChanged(string newMessage)
        {
            typewriterAnimator.Animate(newMessage);
        }
    }
}