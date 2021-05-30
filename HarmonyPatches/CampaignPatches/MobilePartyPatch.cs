using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TOW_Core.CampaignMode;

namespace TOW_Core.HarmonyPatches
{
    public class MobilePartyPatch
    {
        [HarmonyPatch]
        public static class OnGameStateChangePatch
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(MobileParty), "CreateParty")]
            public static void PostFix(ref MobileParty  __result)
            {
                
                if (AttributeSystemManager.Instance != null)
                {
                    AttributeSystemManager.Instance.RegisterParty(__result);
                }
            }
        }

    }
}