using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;

namespace TOW_Core.HarmonyPatches
{
    public static class CrossHairPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(CrosshairWidget))]
        [HarmonyPatch("IsVisible", MethodType.Setter)]
        public static void PreFix(ref bool __result)
        {
            if (__result == false)
            {
                TOWCommon.Log("Crosshair is gone");
                __result = true;
            }
        }
    }
}