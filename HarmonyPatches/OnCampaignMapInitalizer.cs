using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TOW_Core.CampaignMode;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch(typeof(CampaignObjectManager))]
    public static class OnCampaignMapInitalizerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("OnLoad")]
        public static void PostFix()
        {
            Tow_CampaignManager.Instance.Hello();
        }
    }
}


namespace TOW_Core.HarmonyPatches
{
    
    }
