using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TOW_Core.CampaignMode;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class OnCampaignMapInitalizerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CampaignEvents), "OnGameLoaded")]
        public static void PostFix()
        {
            Tow_CampaignManager.Instance.Initialize();
        }
    }

   
    
}

