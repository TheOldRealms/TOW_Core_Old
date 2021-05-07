using HarmonyLib;
using NLog;
using TaleWorlds.MountAndBlade.GauntletUI;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD;
using TOW_Core.Utilities;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class CrossHairPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionGauntletCrosshair), "GetShouldCrosshairBeVisible")]
        public static void PostFix(ref bool  __result)
        {
            __result = true;
        }
        
        
        
    }
}