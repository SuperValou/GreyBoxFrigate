using Assets.Scripts.LoadingSystems.PersistentVariables;
using Assets.Scripts.LoadingSystems.SceneInfos;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.SceneScripts
{
    public class RoomScript : MonoBehaviour
    {
        // -- Editor
        
        [Header("References")]
        public PersistentRoomId playerCurrentRoom;
        
        // -- Class

        [Header("Debug")]
        [SerializeField]
        private PersistentInt _visitCount;

        private SceneId _roomId;

        void Awake()
        {
            _roomId = SceneInfo.GetRoomIdForGameObject(this.gameObject);
            playerCurrentRoom.ValueChanged += OnPlayerRoomChanged;
            OnPlayerRoomChanged(playerCurrentRoom.Value);
        }

        private void OnPlayerRoomChanged(SceneId roomId)
        {
            if (roomId != _roomId)
            {
                return;
            }

            _visitCount.Value++;
        }
        
        protected virtual void OnDestroy()
        {
            playerCurrentRoom.ValueChanged -= OnPlayerRoomChanged;
        }
    }
}