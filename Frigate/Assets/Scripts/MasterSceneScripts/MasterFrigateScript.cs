﻿using System.Collections;
using Assets.Scripts.LoadingSystems.SceneInfos;
using Assets.Scripts.LoadingSystems.SceneInfos.Attributes;
using Assets.Scripts.LoadingSystems.SceneLoadings;
using UnityEngine;

namespace Assets.Scripts.MasterSceneScripts
{
    public class MasterFrigateScript : MonoBehaviour
    {
        // -- Editor

        [Header("Values")]
        [GameplayId]
        public SceneId gameplayToLoad;

        [RoomId]
        public SceneId firstRoomToLoad;

        [Header("References")]
        public SceneLoadingManager sceneLoadingManager;

        // -- Class

        IEnumerator Start()
        {
            yield return sceneLoadingManager.PreloadSubSceneAsync(gameplayToLoad);
            yield return sceneLoadingManager.PreloadSubSceneAsync(firstRoomToLoad);

            sceneLoadingManager.Activate(gameplayToLoad);
            sceneLoadingManager.Activate(firstRoomToLoad);
        }
    }
}