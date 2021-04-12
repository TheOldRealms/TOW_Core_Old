using System;
using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.CustomBattle;
using TaleWorlds.MountAndBlade.CustomBattle.CustomBattle;
using TOW_Core.CustomBattles;
using TOW_Core.Utilities;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class CustomBattlePatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleState.Helper), "GetDefaultTroopOfFormationForFaction")]
        public static void Postfix(ref BasicCharacterObject __result, BasicCultureObject culture, FormationClass formation)
        {
            //var obj = MBObjectManager.Instance.GetObject<BasicCharacterObject>("empire_greatsword");
            var obj = CustomBattleTroopManager.GetTroopObjectFor(culture, formation);
            if (obj != null) __result = obj;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleData), "Characters", MethodType.Getter)]
        public static void Postfix2(ref IEnumerable<BasicCharacterObject> __result)
        {
            var list = new List<BasicCharacterObject>();
            try
            {
                //Ideally this should not be hardcoded. Maybe create a custombattlelords xml template and load that?
                list.Add(Game.Current.ObjectManager.GetObject<BasicCharacterObject>("karlfranz"));
                list.Add(Game.Current.ObjectManager.GetObject<BasicCharacterObject>("mannfred"));
            }
            catch (Exception e)
            {
                TOWCommon.Log(e.Message, NLog.LogLevel.Error);
            }
            if (list.Count > 1) __result = list;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleData), "Factions", MethodType.Getter)]
        public static void Postfix3(ref IEnumerable<BasicCultureObject> __result)
        {
            var list = new List<BasicCultureObject>();
            try
            {
                //Ideally this should not be hardcoded. Maybe create a custombattlecultures xml template and load that?
                list.Add(Game.Current.ObjectManager.GetObject<BasicCultureObject>("empire"));
                list.Add(Game.Current.ObjectManager.GetObject<BasicCultureObject>("khuzait"));
            }
            catch (Exception e)
            {
                Utils.Log(e.Message, NLog.LogLevel.Error);
            }
            if (list.Count > 1) __result = list;
        }
    }
}
