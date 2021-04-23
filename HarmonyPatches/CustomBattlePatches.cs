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
    //This is an insanely hacky class to mould Custom Battle to TOW needs. Does not effect other aspects of gameplay (campaign or else).
    [HarmonyPatch]
    public static class CustomBattlePatches
    {
        //Need to store this, because cannot access __instance in a delegate function (after multiselectioninquiry selection)
        private static ArmyCompositionGroupVM instance;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(CustomBattleState.Helper), "GetDefaultTroopOfFormationForFaction")]
        public static void Postfix(ref BasicCharacterObject __result, BasicCultureObject culture, FormationClass formation)
        {
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
                //TODO! Krell makes the loading screen insanely long.The model itself is bugged somehow.
                //list.Add(Game.Current.ObjectManager.GetObject<BasicCharacterObject>("krell")); 
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
                TOWCommon.Log(e.Message, NLog.LogLevel.Error);
            }
            if (list.Count > 1) __result = list;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ArmyCompositionGroupVM), "ExecuteMeleeInfantryTypeSelection")]
        public static bool Prefix(ref ArmyCompositionGroupVM __instance, BasicCultureObject ____selectedCulture)
        {
            instance = __instance;
            var trooplist = new List<BasicCharacterObject>();
            var selectlist = new List<InquiryElement>();
            Game.Current.ObjectManager.GetAllInstancesOfObjectType<BasicCharacterObject>(ref trooplist);
            trooplist = trooplist.FindAll(c => c.IsSoldier && c.StringId.Contains("tow_") && c.DefaultFormationClass == FormationClass.Infantry && c.Culture == ____selectedCulture);

            foreach (BasicCharacterObject basicCharacterObject in trooplist)
            {
                ImageIdentifier imageIdentifier = new ImageIdentifier(CharacterCode.CreateFrom(basicCharacterObject));
                selectlist.Add(new InquiryElement(basicCharacterObject, basicCharacterObject.Name.ToString(), imageIdentifier));
            }
            InformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData("Melee Infantry Troop Types", string.Empty, selectlist, true, -1, "Done", "", new Action<List<InquiryElement>>(CustomBattlePatches.MeleeSelect), null, ""), false);
            return false;
        }

        private static void MeleeSelect(List<InquiryElement> obj)
        {
            instance.SelectedMeleeInfantryTypes.Clear();
            foreach(var element in obj)
            {
                instance.SelectedMeleeInfantryTypes.Add(element.Identifier as BasicCharacterObject);
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ArmyCompositionGroupVM), "ExecuteRangedInfantryTypeSelection")]
        public static bool Prefix2(ref ArmyCompositionGroupVM __instance, BasicCultureObject ____selectedCulture)
        {
            instance = __instance;
            var trooplist = new List<BasicCharacterObject>();
            var selectlist = new List<InquiryElement>();
            Game.Current.ObjectManager.GetAllInstancesOfObjectType<BasicCharacterObject>(ref trooplist);
            trooplist = trooplist.FindAll(c => c.IsSoldier && c.StringId.Contains("tow_") && c.DefaultFormationClass == FormationClass.Ranged && c.Culture == ____selectedCulture);

            foreach (BasicCharacterObject basicCharacterObject in trooplist)
            {
                ImageIdentifier imageIdentifier = new ImageIdentifier(CharacterCode.CreateFrom(basicCharacterObject));
                selectlist.Add(new InquiryElement(basicCharacterObject, basicCharacterObject.Name.ToString(), imageIdentifier));
            }
            InformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData("Ranged Infantry Troop Types", string.Empty, selectlist, true, -1, "Done", "", new Action<List<InquiryElement>>(CustomBattlePatches.RangedSelect), null, ""), false);
            return false;
        }

        private static void RangedSelect(List<InquiryElement> obj)
        {
            instance.SelectedRangedInfantryTypes.Clear();
            foreach (var element in obj)
            {
                instance.SelectedRangedInfantryTypes.Add(element.Identifier as BasicCharacterObject);
            }
        }
    }
}
