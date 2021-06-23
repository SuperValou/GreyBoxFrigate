using UnityEngine;

namespace Assets.Scripts.SceneScripts.RoomConfigurations
{
    public abstract class RoomConfigurator : MonoBehaviour
    {
        // -- Inspector

        [SerializeField]
        private string _configName;
        
        // -- Class

        public string ConfigName => _configName;

        public abstract void Enable();

        public abstract void Disable();

#if UNITY_EDITOR
        // Called in the editor only when the script is loaded or a value is changed in the Inspector
        void OnValidate()
        {
            if (!this.gameObject.activeInHierarchy)
            {
                return;
            }

            string debugName = $"{this.GetType().Name} - {this._configName}";
            if (this.name != debugName)
            {
                this.name = debugName;
            }
        }
#endif
    }
}