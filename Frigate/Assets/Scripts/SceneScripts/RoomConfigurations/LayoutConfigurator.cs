using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SceneScripts.RoomConfigurations
{
    public class LayoutConfigurator : RoomConfigurator
    {
        // -- Inspector

        [Tooltip("Game objects affected by this layout.")]
        public List<GameObject> gameObjects;

        [Tooltip("State of the game objects when this layout is enabled. " +
                 "In another way: set to false when you want the game objets to be disabled when this layout gets enabled.")]
        public bool setActive;

        // -- Class

        public override void Enable()
        {
            foreach (var gameObj in gameObjects)
            {
                gameObj.SetActive(setActive);
            }
        }

        public override void Disable()
        {
            foreach (var gameObj in gameObjects)
            {
                gameObj.SetActive(!setActive);
            }
        }
    }
}