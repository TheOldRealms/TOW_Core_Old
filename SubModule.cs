using HarmonyLib;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Texts;
using TOW_Core.CustomBattles;
using NLog;
using System;
using NLog.Targets;
using NLog.Config;
using TOW_Core.Battle.AttributeSystem;
using TOW_Core.Battle.AttributeSystem.CustomMissionLogic;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;
using TOW_Core.Utilities.Extensions;

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
            ConfigureLogging();
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
            LoadAttributes();
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);

            InitializeAttributeSystemForMission(mission);
        }

        private void InitializeAttributeSystemForMission(Mission mission)
        {
            mission.AddMissionBehaviour(new AttributeSystemMissionLogic());

            // Replace the default morale interaction logic with our new custom morale logic
            mission.RemoveMissionBehaviourIfNotNull(mission.GetMissionBehaviour<AgentMoraleInteractionLogic>());
            mission.AddMissionBehaviour(new TOWAgentMoraleInteractionLogic());
        }

        private void LoadAttributes()
        {
            AttributeManager attributeManager = new AttributeManager();
            attributeManager.LoadAttributes();
        }

        private static void ConfigureLogging()
        {
            var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/Logs/${LogHome}${date:format=yyyy}/${date:format=MMMM}/${date:format=dd}/TOW_log${shortdate}.txt");
            var config = new LoggingConfiguration();

            // Log debug/exception info to the log file
            var logfile = new FileTarget("logfile") { FileName = path };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Log info and higher to the VS debugger
            var logdebugger = new DebuggerTarget("logdebugger");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logdebugger);

            LogManager.Configuration = config;
        }
    }
}