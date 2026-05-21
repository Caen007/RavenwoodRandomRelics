using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Managers;
using UnityEngine;

namespace RavenwoodRandomRelics
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class RavenwoodRandomRelics : BaseUnityPlugin
    {
        public const string PluginGUID = "Ravenwood.RandomRelics";
        public const string PluginName = "Ravenwood Random Relics";
        public const string PluginVersion = "1.0.5";

        private AssetBundle relicsBundle;

        public static ConfigEntry<string> PlayerPreferredCategory;

        private ConfigEntry<bool> LockConfiguration;

        private void Awake()
        {
            new Harmony("ravenwood.randomrelics.harmony").PatchAll();

            LockConfiguration = Config.Bind(
                "General",
                "Lock Configuration",
                true,
                "If on, server controls the config and clients cannot change it."
            );

            PlayerPreferredCategory = Config.Bind(
                "UI",
                "CustomHammerTab",
                "RavenwoodRelics",
                "Custom hammer tab category name"
            );

            var asm = Assembly.GetExecutingAssembly();
            const string wanted = "ravenwoodrandomrelics";
            string resName = asm.GetManifestResourceNames()
                                .FirstOrDefault(r => r.ToLower().Contains(wanted));

            if (string.IsNullOrEmpty(resName))
            {
                Logger.LogError($"Could not find embedded asset bundle resource containing '{wanted}'.");
                return;
            }

            using (var s = asm.GetManifestResourceStream(resName))
            {
                if (s == null)
                {
                    Logger.LogError($"Embedded asset bundle stream was null for '{resName}'.");
                    return;
                }

                using (var ms = new MemoryStream())
                {
                    s.CopyTo(ms);
                    relicsBundle = AssetBundle.LoadFromMemory(ms.ToArray());
                }
            }

            if (relicsBundle == null)
            {
                Logger.LogError("Failed to load AssetBundle from embedded resource!");
                return;
            }

            PrefabManager.OnPrefabsRegistered += RegisterNow;
        }

        private void RegisterNow()
        {
            if (relicsBundle == null) return;

            RelicRegistrar.RegisterAllRelics(relicsBundle);

            Logger.LogInfo($"[RavenwoodRelics] Registration complete. Hammer tab: '{PlayerPreferredCategory.Value}'.");
        }
    }
}