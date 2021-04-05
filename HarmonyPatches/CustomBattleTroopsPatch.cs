using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.CustomBattle;
using TaleWorlds.ObjectSystem;
using TOW_Core.CustomBattles;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch(typeof(CustomBattleState.Helper))]
    public static class CustomBattleTroopsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GetDefaultTroopOfFormationForFaction")]
        public static void Postfix(ref BasicCharacterObject __result, BasicCultureObject culture, FormationClass formation)
        {
            //var obj = MBObjectManager.Instance.GetObject<BasicCharacterObject>("empire_greatsword");
            var obj = CustomBattleTroopManager.GetTroopObjectFor(culture, formation);
            if (obj != null) __result = obj;
        }
    }
}
