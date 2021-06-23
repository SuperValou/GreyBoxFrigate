using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.LoadingSystems.PersistentVariables;
using UnityEngine;

namespace Assets.Scripts.SceneScripts.RoomConfigurations
{
    public class RoomConfiguration : MonoBehaviour
    {
        // -- Inspector

        [Header("Parts")]
        public PersistentString activeConfigName;

        [Header("Reference")]
        public List<RoomConfigurator> configurators;

        // -- Class

        private const string DefaultConfigName = "Default";

        void Awake()
        {
            if (activeConfigName.Value == string.Empty)
            {
                activeConfigName.Value = DefaultConfigName;
            }

            var configuratorsToDisable = configurators.Where(c => c.ConfigName != activeConfigName.Value);
            foreach (var configurator in configuratorsToDisable)
            {
                configurator.Disable();
            }

            var configuratorsToEnable = configurators.Where(c => c.ConfigName == activeConfigName.Value);
            if (activeConfigName.Value != DefaultConfigName && !configuratorsToEnable.Any())
            {
                Debug.LogWarning($"The active configuration is '{activeConfigName.Value}', but nothing corresponds to it. " +
                                 $"Available configs are '{string.Join(", ", configurators.Select(c => c.ConfigName))}'. " +
                                 $"Did you mispelled something?");
            }
            else
            {
                foreach (var configurator in configuratorsToEnable)
                {
                    configurator.Enable();
                }
            }
        }
    }
}