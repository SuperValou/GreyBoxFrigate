using Assets.Scripts.Players;
using UnityEngine;

namespace Assets.Scripts.Cutscenes
{
    public class BossDeath : MonoBehaviour
    {
        // -- Editor
        public PlayerSharedData playerSharedData;

        // -- Class

        public void Activate()
        {
            playerSharedData.IsInvulnerable = true;

        }
    }
}