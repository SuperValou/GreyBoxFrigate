using System;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.CrossSceneData
{
    [CreateAssetMenu(fileName = nameof(SharedString), menuName = "CrossSceneObjects/" + nameof(SharedString))]
    public class SharedString : ScriptableObject
    {
        [SerializeField]
        private string _value = string.Empty;

        public string Value => _value;

        public event Action<string> ValueChanged;

        public void Set(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (_value == str)
            {
                return;
            }

            _value = str;
            ValueChanged.SafeInvoke(_value);
        }

        public void Reset()
        {
            if (_value == string.Empty)
            {
                return;
            }

            _value = string.Empty;
            ValueChanged.SafeInvoke(_value);
        }

        void OnDisable()
        {
            // Clear value
            _value = string.Empty;
        }
    }
}