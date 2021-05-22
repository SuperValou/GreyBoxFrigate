using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.TypewriterEffects;
using Assets.Scripts.TypewriterEffects.Notifiables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Huds
{
    public class MessageDisplay : MonoBehaviour, ITypingNotifiable
    {
        // -- Editor

        [Header("Values")]
        public float delayBetweenMessages = 3;

        [Header("Parts")]
        public TypewriterAnimator typewriterAnimator;

        // -- Class
        private readonly object _lock = new object();
        private readonly Queue<string> _queue = new Queue<string>();

        void Start()
        {
            // TODO: move to TutoRoomScript
            this.DisplayMessage("Use <anim:wave>\u243E</anim> to look around.");
            this.DisplayMessage("Use <anim:blink>ZQSD</anim> to move.");
            this.DisplayMessage("Press <anim:blink>space</anim> to jump.");
        }

        public void DisplayMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            bool shouldDisplay;
            lock (_lock)
            {
                _queue.Enqueue(message);
                shouldDisplay = _queue.Count == 1;
            }

            if (shouldDisplay)
            {
                DisplayNextMessage();
            }
        }

        private void DisplayNextMessage()
        {
            string text;
            lock (_lock)
            {
                if (_queue.Count == 0)
                {
                    // TODO: add a Clear() method or smth
                    typewriterAnimator.Animate(string.Empty);
                    return;
                }

                text = _queue.Peek();
            }
            
            typewriterAnimator.Animate(text);
        }

        public void OnTypingBegin()
        {
            // do nothing
        }

        public void OnCaretMove()
        {
            // do nothing
        }

        public void OnTypingEnd()
        {
            lock (_lock)
            {
                if (_queue.Count == 0)
                {
                    return;
                }

                _queue.Dequeue();
            }

            Invoke(nameof(DisplayNextMessage), delayBetweenMessages);
        }
    }
}