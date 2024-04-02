using BepInEx;
using HarmonyLib;

namespace InfiniteOxygenContentWarning
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class InfiniteOxygen : BaseUnityPlugin
    {
        private const string modGUID = "komen205.InfiniteOxygen";
        private const string modName = "InfiniteOxygen";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private void Awake()
        {
            harmony.PatchAll();

            Logger.LogInfo($"Plugin {modGUID} is loaded!");
        }

        [HarmonyPatch(typeof(Player.PlayerData))]
        internal class PlayerDataPatch
        {
            [HarmonyPatch("UpdateValues")]
            [HarmonyPrefix]
            static void IsGameFullPatch(ref float ___remainingOxygen)
            {
                ___remainingOxygen = 500f;
            }
        }
    }
}
