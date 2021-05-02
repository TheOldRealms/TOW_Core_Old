using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;

namespace TOW_Core.HarmonyPatches
{
    public static class CrossHairPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CrosshairWidget), "IsVisible")]
        public static void PostFix(ref bool __result)
        {
            if (__result == false)
            {
                __result = true;
            }
        }
    }
}