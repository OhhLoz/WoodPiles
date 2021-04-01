using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using UnityEngine;
using JotunnLib;
using JotunnLib.Managers;
using System;
using JotunnLib.Utils;

namespace WoodPiles
{
    public static class RecipeHandler
    {
        public static AssetBundle assetBundle;
        public static readonly Dictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();
        public static GameObject coreWoodStack, fineWoodStack;

        public static void Init()
        {
            Debug.Log("[WoodPiles] Initialising");

            assetBundle = AssetHelper.LoadAssetBundle("woodpileassets");
            if (assetBundle != null)
            {
                coreWoodStack = assetBundle.LoadAsset<GameObject>("Assets/Prefabs/core_wood_stack.prefab");
                fineWoodStack = assetBundle.LoadAsset<GameObject>("Assets/Prefabs/fine_wood_stack.prefab");
            }

            assetBundle?.Unload(false);

            PrefabManager.Instance.PrefabRegister += registerPrefabs;
            PieceManager.Instance.PieceRegister += registerPieces;
        }

        private static void registerPrefabs(object sender, EventArgs e)
        {
            ReflectionUtils.InvokePrivate(PrefabManager.Instance, "RegisterPrefab", new object[] { coreWoodStack, "core_wood_pile" });
            ReflectionUtils.InvokePrivate(PrefabManager.Instance, "RegisterPrefab", new object[] { fineWoodStack, "fine_wood_pile" });
        }

        private static void registerPieces(object sender, EventArgs e)
        {
            PieceManager.Instance.RegisterPiece("Hammer", "core_wood_pile");
            PieceManager.Instance.RegisterPiece("Hammer", "fine_wood_pile");
        }
    }
}
