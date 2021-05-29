using System;
using System.Collections;
using Assets.Scripts.TypewriterEffects;
using Assets.Scripts.TypewriterEffects.Notifiables;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Huds
{
    public class MessageDisplay : MonoBehaviour, ITypingNotifiable
    {
        // -- Editor

        [Header("Values")]
        public float delayBetweenMessages = 3;

        [Header("Parts")]
        public TypewriterAnimator typewriterAnimator;

        [Header("References")]
        public SharedStringQueue messageQueue;

        // -- Class

        private bool _isDisplaying;

        void Start()
        {
            // TODO: add a Clear method
            typewriterAnimator.Animate(string.Empty);
        }

        void Update()
        {
            if (_isDisplaying)
            {
                return;
            }

            if (!messageQueue.TryDequeue(out string message))
            {
                return;
            }

            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            typewriterAnimator.Animate(message);
            _isDisplaying = true;
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
            StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(delayBetweenMessages);

            // TODO: add a Clear() method
            typewriterAnimator.Animate(string.Empty);
            _isDisplaying = false;
        }
    }
}