using HarmonyLib;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Texts;
using TOW_Core.CustomBattles;

namespace TOW_Core
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            InformationManager.DisplayMessage(new InformationMessage("TOW Core loaded."));
        }

        protected override void OnSubModuleLoad()
        {
            Harmony harmony = new Harmony("mod.harmony.theoldworld");
            harmony.PatchAll();
        }

        /// <summary>
        /// This is the main game start.
        /// </summary>
        /// <param name="game"></param>
        public override void BeginGameStart(Game game)
        {
            //TOWTextManager.WriteSampleOverrideXml();
            //CustomBattleTroopManager.WriteSampleOverrideXml();
            TOWTextManager.LoadAdditionalTexts();
            TOWTextManager.LoadTextOverrides();
            CustomBattleTroopManager.LoadCustomBattleTroops();
        }
    }
}