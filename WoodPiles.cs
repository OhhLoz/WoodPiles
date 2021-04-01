using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace WoodPiles
{
    [BepInDependency(JotunnLib.JotunnLib.ModGuid)]
    [BepInPlugin(modGuid, modName, modVer)]
    [BepInProcess("valheim.exe")]
    public class WoodPiles : BaseUnityPlugin
    {
        public const string modAuthor = "Loz";
        public const string modGuid = "Loz." + modName;
        private const string modName = "WoodPiles";
        private const string modVer = "1.0.0";

        internal static WoodPiles Instance { get; private set; }

        void Awake()
        {
            Debug.Log("[WoodPiles] Awake()");

            RecipeHandler.Init();

            Instance = this;
        }
    }
}
