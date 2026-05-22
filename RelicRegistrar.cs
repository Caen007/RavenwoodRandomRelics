using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace RavenwoodRandomRelics
{
    public class RelicRegistration
    {
        public string PrefabName;
        public string DisplayName;
        public RequirementConfig[] Requirements;
        public string Description;
        public int Comfort;
        public bool IsWerewolf;
        public bool IsHorn;

        public RelicRegistration(string prefab, string display, RequirementConfig[] reqs, string desc, int comfort = 0, bool isWerewolf = false, bool isHorn = false)
        {
            PrefabName = prefab;
            DisplayName = display;
            Requirements = reqs;
            Description = desc;
            Comfort = comfort;
            IsWerewolf = isWerewolf;
            IsHorn = isHorn;
        }
    }

    public static class RelicRegistrar
    {
        private static readonly List<GameObject> placedWerewolves = new();

        private static bool wasAlreadyRegistered = false;

        public static readonly List<RelicRegistration> AllRegistrations = new()
        {
            new RelicRegistration("valkyrie", "Norse Valkyrie", new[] {
                new RequirementConfig("Bronze", 100), new RequirementConfig("FineWood", 25)
            }, "Norse Valkyrie."),

            new RelicRegistration("armor", "Dark Knight", new[] {
                new RequirementConfig("Iron", 20), new RequirementConfig("FineWood", 15)
            }, "A custom decorative piece."),

            new RelicRegistration("R_KnightArmour", "Knight Armour", new[] {
                new RequirementConfig("Iron", 20), new RequirementConfig("FineWood", 15)
            }, "A custom decorative piece."),

            new RelicRegistration("OdinGuard", "Heimdall", new[] {
                new RequirementConfig("Bronze", 20), new RequirementConfig("FineWood", 15)
            }, "Guardian of Bifröst."),

            new RelicRegistration("werewolf", "Fenrir the Devourer", new[] {
                new RequirementConfig("TrophyFenring", 1), new RequirementConfig("IronNails", 20), new RequirementConfig("Tar", 20)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("werewolfmirrored", "Fenrir the Devourer mirrored", new[] {
                new RequirementConfig("TrophyFenring", 1), new RequirementConfig("IronNails", 20), new RequirementConfig("Tar", 20)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("werewolfbust", "Fenrir Bust", new[] {
                new RequirementConfig("TrophyFenring", 1), new RequirementConfig("Stone", 20)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("gargoyledog", "Gargoyle I", new[] {
                new RequirementConfig("Stone", 10), new RequirementConfig("FineWood", 5), new RequirementConfig("Coins", 10)
            }, "A custom decorative piece."),

            new RelicRegistration("v2_gargoylestatue", "Gargoyle II", new[] {
                new RequirementConfig("Stone", 10), new RequirementConfig("FineWood", 5), new RequirementConfig("Coins", 10)
            }, "A custom decorative piece."),

            new RelicRegistration("lion", "Lion Statue", new[] {
                new RequirementConfig("Stone", 40), new RequirementConfig("Coins", 40)
            }, "The Lion King."),

            new RelicRegistration("JapaneseStoneLantern", "Japanese Stone Lantern", new[] {
                new RequirementConfig("Stone", 20), new RequirementConfig("Resin", 20)
            }, "A custom decorative piece." ),

            new RelicRegistration("pedestalplanter", "Pedestal Planter", new[] {
                new RequirementConfig("Stone", 15), new RequirementConfig("Resin", 20)
            }, "A decorative stone urn, perfect for gardens or noble estates."),

            new RelicRegistration("clock", "Wooden Big Ben Clock", new[] {
                new RequirementConfig("Wood",25), new RequirementConfig("FineWood", 15)
            }, "A custom decorative piece.",0, false, false),

            new RelicRegistration("SWC", "Vintage Swiss Wooden Cuckoo Clock", new[] {
                new RequirementConfig("Wood",10), new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 20)
            }, "A custom decorative piece.", 0, false, false),

            new RelicRegistration("HornX", "Horn of Thor", new[] {
                new RequirementConfig("BoneFragments", 25), new RequirementConfig("Copper", 5)
            }, "Sound the horn to alert your allies.", 0, false, true),

            new RelicRegistration("HotAirBalloon", "Hot Air Balloon", new[] {
                new RequirementConfig("GreydwarfEye", 10), new RequirementConfig("Coins", 10)
            }, "A custom decorative piece.", 1),

            new RelicRegistration("Picture1", "Ravenwood Vikings", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("Picture2", "Ravenwood Vikings II", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("Picture3", "Ravenwood Vikings III", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("Picture4", "Ravenwood Vikings IV", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("Picture5", "Ravenwood Vikings V", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("Vikings", "Ravenwood Vikings VI", new[] {
                new RequirementConfig("Wood", 10), new RequirementConfig("FineWood", 10)
            }, "Custom decorative picture."),

            new RelicRegistration("WitchCat", "WitchCat", new[] {
                new RequirementConfig("Coins", 50)
            }, "A big comfy witchcat. Provides +1 comfort.", 1),

            new RelicRegistration("WoodenBear", "Wooden Brown Bear", new[] {
                new RequirementConfig("Coins", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("bouquet", "Flower Bouquet", new[] {
                new RequirementConfig("Thistle", 20), new RequirementConfig("Dandelion", 5)
            }, "A custom decorative piece.", 1),

            new RelicRegistration("AsianTeaSet","Asian Tea Set", new[] {
                new RequirementConfig("Stone", 5), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("AsianTeaSetPlate","Asian Tea Set Plate", new[] {
                new RequirementConfig("FineWood", 5), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("porcelainteaset", "Porcelain Tea Set", new[] {
                new RequirementConfig("Stone", 5), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("skullgoblet", "Skull Goblet", new[] {
                new RequirementConfig("BoneFragments", 15), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("TP", "Toilet Paper", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("Dandelion", 5)
            }, "A custom decorative piece.", 0, false, false),

            new RelicRegistration("v2_NiceChair", "Chair of the Windweaver", new[] {
                new RequirementConfig("Wood", 15), new RequirementConfig("DeerHide", 5)
            }, "A custom decorative piece.", 0, false, false),

            new RelicRegistration("v2_PersianRug", "World Tree Rug", new[] {
                new RequirementConfig("FineWood", 2), new RequirementConfig("DeerHide", 2)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("DragonBanner", "The Red Dragon", new[] {
                new RequirementConfig("FineWood", 5), new RequirementConfig("Bronze", 3),new RequirementConfig("JuteRed", 3)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("DutchBanner", "Banner of Kings", new[] {
                new RequirementConfig("FineWood", 2), new RequirementConfig("DeerHide", 2), new RequirementConfig("Bronze", 1), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("v2_Lionking", "Banner of a Lion", new[] {
                new RequirementConfig("FineWood", 2), new RequirementConfig("DeerHide", 2), new RequirementConfig("Bronze", 1), new RequirementConfig("Coins", 5)
            }, "A custom decorative piece.", 0, true),

            new RelicRegistration("JapaneseToriiGate", "Japanese Torii Gate I", new[] {
                new RequirementConfig("Wood", 20), new RequirementConfig("FineWood", 20)
            }, "A custom decorative piece."),

            new RelicRegistration("JPGate", "Japanese Torii Gate II", new[] {
                new RequirementConfig("Wood", 20), new RequirementConfig("FineWood", 20)
            }, "A custom decorative piece."),

             new RelicRegistration("Chinese_Lamp", "Warden’s Lantern", new[] {
                new RequirementConfig("Stone", 20), new RequirementConfig("Resin", 20)
            }, "A custom decorative piece."),

            // New Added additions

            new RelicRegistration("bear", "Bear Statue", new[] {
                new RequirementConfig("Stone", 5), new RequirementConfig("FineWood", 5),new RequirementConfig("Coins", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("blackdragonskeleton", "Dark Angel", new[] {
                new RequirementConfig("Iron", 20), new RequirementConfig("FineWood", 20), new RequirementConfig("Coins", 100)
            }, "A custom decorative piece."),

            new RelicRegistration("dragon", "Draco", new[] {
                new RequirementConfig("Eitr", 333), new RequirementConfig("Coins", 3333)
            }, "A custom decorative piece."),

            new RelicRegistration("throne", "Odin", new[] {
                new RequirementConfig("Stone", 100), new RequirementConfig("Bronze", 100),new RequirementConfig("Coins", 1000)
            }, "A custom decorative piece."),

            new RelicRegistration("greythrone", "Grey throne", new[] {
                new RequirementConfig("Stone", 100), new RequirementConfig("Bronze", 20), new RequirementConfig("Coins", 200)
            }, "A custom decorative piece."),

            new RelicRegistration("whitethrone", "White throne", new[] {
                new RequirementConfig("Stone", 100), new RequirementConfig("Bronze", 20), new RequirementConfig("Coins", 200)
            }, "A custom decorative piece."),

            new RelicRegistration("blackthrone", "Black throne", new[] {
                new RequirementConfig("Stone", 100), new RequirementConfig("Bronze", 20), new RequirementConfig("Coins", 200)
            }, "A custom decorative piece."),

            new RelicRegistration("goldenthrone", "Gold throne", new[] {
                new RequirementConfig("Stone", 100), new RequirementConfig("Bronze", 20), new RequirementConfig("Coins", 200)
            }, "A custom decorative piece."),

            new RelicRegistration("BoatinBottle", "The Black Pearl", new[] {
                new RequirementConfig("Coins", 10), new RequirementConfig("FineWood", 10)
            }, "A custom decorative piece."),

            new RelicRegistration("DeerGlobe", "Deer in Snow Globe", new[] {
                new RequirementConfig("Coins", 10), new RequirementConfig("FineWood", 10)
            }, "A custom decorative piece."),

            new RelicRegistration("Rose", "Rose in a Globe", new[] {
                new RequirementConfig("Thistle", 10), new RequirementConfig("Coins", 10)
            }, "A custom decorative piece."),

            new RelicRegistration("horse", "Horse Bust Statue", new[] {
                new RequirementConfig("Stone", 10), new RequirementConfig("FineWood", 10)
            }, "A custom decorative piece."),
            
            //Trees
            
            new RelicRegistration("ItalianCypress0", "Italian Cypress Tree Tall Orange", new[] {
                new RequirementConfig("FineWood", 20)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("ItalianCypress1", "Italian Cypress Tree Tall Green", new[] {
                new RequirementConfig("FineWood", 20)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("ItalianCypress2", "Italian Cypress Tree Medium Green", new[] {
                 new RequirementConfig("FineWood", 10)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("ItalianCypress3", "Italian Cypress Small Green", new[] {
                 new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("ItalianCypress4", "Italian Cypress Small Orange", new[] {
                 new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Massive", "Italian Cypress Tree Massive", new[] {
                 new RequirementConfig("FineWood", 20)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Large_A", "Italian Cypress Tree Large Wide", new[] {
                 new RequirementConfig("FineWood", 10)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Large_B", "Italian Cypress Tree Large Thin", new[] {
                new RequirementConfig("FineWood", 10)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Large_B1", "Italian Cypress Tree Extra Large ", new[] {
                new RequirementConfig("FineWood", 30)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Medium_B", "Italian Cypress Tree Small", new[] {
                new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Growing_A", "Italian Cypress Tree Growing", new[] {
                new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Growing_E", "Italian Cypress Tree Growing Wide", new[] {
                  new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),

            new RelicRegistration("SM_ItalianCypress_Growing_C", "Italian Cypress Tree Growing Thin", new[] {
                 new RequirementConfig("FineWood", 5)
            }, "A tall decorative cypress tree."),
            
            //Trophies
            
            new RelicRegistration("BearHead", "Bear Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("BoarHead", "Boar Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("DeerHead", "Deer Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("ElephantHead", "Elephant Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("HippoHead", "Hippo Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("LionHead", "Lion Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            new RelicRegistration("RhinoHead", "Rhino Head Trophy", new[] {
                new RequirementConfig("FineWood", 10), new RequirementConfig("Coins", 40)
            }, "A custom decorative piece."),

            // Picture_A series
            new RelicRegistration("Picture_01_A", "Picture 01 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_02_A", "Picture 02 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_03_A", "Picture 03 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_04_A", "Picture 04 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_05_A", "Picture 05 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_06_A", "Picture 06 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_07_A", "Picture 07 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_08_A", "Picture 08 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_09_A", "Picture 09 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_10_A", "Picture 10 A", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            // Picture_B series

            new RelicRegistration("Picture_01_B", "Picture 01 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_02_B", "Picture 02 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_03_B", "Picture 03 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_04_B", "Picture 04 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_05_B", "Picture 05 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_06_B", "Picture 06 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_07_B", "Picture 07 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_08_B", "Picture 08 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_09_B", "Picture 09 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            new RelicRegistration("Picture_10_B", "Picture 10 B", new[] {
                new RequirementConfig("Wood", 5), new RequirementConfig("FineWood", 5)
            }, "A custom decorative piece."),

            // Crystals

            new RelicRegistration("Frost_Crystal", "Frost Crystal", new[] {
                new RequirementConfig("Crystal", 5)
            }, "A custom decorative piece.")
       };

        public static void RegisterAllRelics(AssetBundle bundle)
        {
            if (wasAlreadyRegistered) return;

            if (bundle == null)
            {
                Debug.LogError("[RavenwoodRelics] AssetBundle is null. Registration stopped.");
                return;
            }

            int ok = 0, fail = 0;
            foreach (var reg in AllRegistrations)
            {
                if (RegisterRelic(bundle, reg)) ok++; else fail++;
            }

            wasAlreadyRegistered = true;

            Debug.Log($"[RavenwoodRelics] Registered {ok}/{AllRegistrations.Count} relics. Failed: {fail}.");
        }

        private static bool RegisterRelic(AssetBundle bundle, RelicRegistration reg)
        {
            if (bundle == null) return false;

            if (reg == null || string.IsNullOrWhiteSpace(reg.PrefabName))
            {
                Debug.LogWarning("[RavenwoodRelics] Skipped a null or empty relic registration.");
                return false;
            }

            GameObject prefab = bundle.LoadAsset<GameObject>(reg.PrefabName);
            if (prefab == null)
            {
                Debug.LogWarning($"[RavenwoodRelics] Missing prefab in AssetBundle: {reg.PrefabName}");
                return false;
            }

            prefab.name = reg.PrefabName;

            var znv = prefab.GetComponent<ZNetView>();
            if (znv == null)
                znv = prefab.AddComponent<ZNetView>();
            znv.m_persistent = true;
            znv.m_syncInitialScale = true;

            // --- Do not change anything else below this line ---
            Piece piece = prefab.GetComponent<Piece>() ?? prefab.AddComponent<Piece>();
            piece.m_name = reg.DisplayName;
            piece.m_description = reg.Description;
            piece.m_comfort = reg.Comfort;
            piece.m_groundOnly = false;

            GameObject vfxPlace, sfxPlace, destroyVFX, destroySFX;

            SFX_VFX_Registry.GetEffects(
                reg.PrefabName,
                out vfxPlace,
                out sfxPlace,
                out destroyVFX,
                out destroySFX
            );

            var placeFX = new EffectList();
            var placeList = new List<EffectList.EffectData>();
            if (vfxPlace != null) placeList.Add(new EffectList.EffectData { m_prefab = vfxPlace, m_enabled = true });
            if (sfxPlace != null) placeList.Add(new EffectList.EffectData { m_prefab = sfxPlace, m_enabled = true });
            placeFX.m_effectPrefabs = placeList.ToArray();
            piece.m_placeEffect = placeFX;

            WearNTear wear = prefab.GetComponent<WearNTear>() ?? prefab.AddComponent<WearNTear>();
            wear.m_health = 1000000f;
            wear.m_noRoofWear = true;

            var destroyFX = new EffectList();
            var destroyList = new List<EffectList.EffectData>();
            if (destroyVFX != null) destroyList.Add(new EffectList.EffectData { m_prefab = destroyVFX, m_enabled = true });
            if (destroySFX != null) destroyList.Add(new EffectList.EffectData { m_prefab = destroySFX, m_enabled = true });
            destroyFX.m_effectPrefabs = destroyList.ToArray();
            wear.m_destroyedEffect = destroyFX;

            // ICONS: exact-name lookup to match your bundle (no lowercase)
            Sprite icon = bundle.LoadAsset<Sprite>(reg.PrefabName);
            if (icon != null) piece.m_icon = icon;

            string craftingStation = "piece_workbench";

            // Make Cypress trees buildable anywhere (no workbench)
            if (reg.PrefabName.StartsWith("ItalianCypress") || reg.PrefabName.StartsWith("SM_ItalianCypress"))
            {
                craftingStation = null;
            }

            var config = new PieceConfig
            {
                PieceTable = "Hammer",
                Category = RavenwoodRandomRelics.PlayerPreferredCategory.Value,
                CraftingStation = craftingStation,
                Requirements = reg.Requirements
            };


            if (reg.IsHorn && prefab.GetComponent<HornOfThor>() == null)
                prefab.AddComponent<HornOfThor>();

            PieceManager.Instance.AddPiece(new CustomPiece(prefab, true, config));

            if (reg.IsWerewolf && prefab.GetComponent<PlacementWatcher>() == null)
                prefab.AddComponent<PlacementWatcher>().RegisterList = placedWerewolves;


            return true;
        }
    }
}