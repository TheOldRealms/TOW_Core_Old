using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TOW_Core.CampaignMode;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class OnGameStateChangePatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Campaign), "OnStateChanged")]
        public static void PostFix()
        {
            if(Tow_CampaignManager.Instance!=null)
                Tow_CampaignManager.Instance.Hello();
        }
    }
    
}