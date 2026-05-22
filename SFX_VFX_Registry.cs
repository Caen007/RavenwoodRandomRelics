using System.Collections.Generic;
using UnityEngine;

namespace RavenwoodRandomRelics
{
    public static class SFX_VFX_Registry
    {
        private static readonly HashSet<string> MetalObjects = new()
        {
            "OdinGuard",
            "armor",
            "Chinese_Lamp",
            "blackdragonskeleton"
        };

        private static readonly HashSet<string> WoodObjects = new()
        {
            "WoodenBear",
            "v2_PersianRug",
            "HotAirBalloon",
            "clock",
            "JapaneseToriiGate",
            "JPGate",
            "TP",
            "Vikings",
            "SWC",
            "Trophy_Deer",

            "ItalianCypress0",
            "ItalianCypress1",
            "ItalianCypress2",
            "ItalianCypress3",
            "ItalianCypress4",
            "SM_ItalianCypress_Massive",
            "SM_ItalianCypress_Large_A",
            "SM_ItalianCypress_Large_B",
            "SM_ItalianCypress_Large_B1",
            "SM_ItalianCypress_Medium_B",
            "SM_ItalianCypress_Growing_A",
            "SM_ItalianCypress_Growing_E",
            "SM_ItalianCypress_Growing_C",

            "Picture1",
            "Picture2",
            "Picture3",
            "Picture4",
            "Picture5",

            "Picture_01_A",
            "Picture_02_A",
            "Picture_03_A",
            "Picture_04_A",
            "Picture_05_A",
            "Picture_06_A",
            "Picture_07_A",
            "Picture_08_A",
            "Picture_09_A",
            "Picture_10_A",

            "Picture_01_B",
            "Picture_02_B",
            "Picture_03_B",
            "Picture_04_B",
            "Picture_05_B",
            "Picture_06_B",
            "Picture_07_B",
            "Picture_08_B",
            "Picture_09_B",
            "Picture_10_B"
        };

        private static readonly HashSet<string> CrystalObjects = new()
        {
            "skullgoblet",
            "porcelainteaset",
            "AsianTeaSet",
            "AsianTeaSetPlate",
            "DeerGlobe",
            "BoatinBottle",
            "Rose",
            "Frost_Crystal"
        };

        public static void GetEffects(
            string prefabName,
            out GameObject vfxPlace,
            out GameObject sfxPlace,
            out GameObject destroyVFX,
            out GameObject destroySFX)
        {
            if (prefabName == "HornX")
            {
                vfxPlace = null;
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_hammer_crystal");
                destroyVFX = null;
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_clay_pot_break");
                return;
            }

            if (MetalObjects.Contains(prefabName))
            {
                vfxPlace = ZNetScene.instance?.GetPrefab("vfx_Place_stone");
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_hammer_metal");
                destroyVFX = ZNetScene.instance?.GetPrefab("vfx_destroyed");
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_metal_blocked");
                return;
            }

            if (WoodObjects.Contains(prefabName))
            {
                vfxPlace = ZNetScene.instance?.GetPrefab("vfx_Place_wood");
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_hammer_wood");
                destroyVFX = ZNetScene.instance?.GetPrefab("vfx_destroyed");
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_wood_break");
                return;
            }

            if (prefabName == "bouquet")
            {
                vfxPlace = ZNetScene.instance?.GetPrefab("vfx_Place_flower");
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_cultivator");
                destroyVFX = ZNetScene.instance?.GetPrefab("vfx_bush_destroyed");
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_bush_hit");
                return;
            }

            if (CrystalObjects.Contains(prefabName))
            {
                vfxPlace = null;
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_hammer_crystal");
                destroyVFX = null;
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_clay_pot_break");
                return;
            }

            if (prefabName == "werewolf" || prefabName == "werewolfmirrored")
            {
                vfxPlace = null;
                sfxPlace = ZNetScene.instance?.GetPrefab("sfx_fenring_howl");
                destroyVFX = null;
                destroySFX = ZNetScene.instance?.GetPrefab("sfx_fenring_death");
                return;
            }

            vfxPlace = ZNetScene.instance?.GetPrefab("vfx_Place_stone");
            sfxPlace = ZNetScene.instance?.GetPrefab("sfx_build_hammer_stone");
            destroyVFX = ZNetScene.instance?.GetPrefab("vfx_destroyed");
            destroySFX = ZNetScene.instance?.GetPrefab("sfx_rock_destroyed");
        }
    }
}