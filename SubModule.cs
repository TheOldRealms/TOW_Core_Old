using HarmonyLib;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Texts;
using TOW_Core.CustomBattles;
using NLog;
using NLog.Targets;
using NLog.Config;
using TOW_Core.Battle.AttributeSystem;
using TOW_Core.Battle.AttributeSystem.CustomMissionLogic;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;
using TOW_Core.Utilities.Extensions;
using TOW_Core.Utilities;
using TOW_Core.Battle.AttributeSystem.CustomBattleMoralModel;
using TaleWorlds.MountAndBlade.CustomBattle;
using TaleWorlds.GauntletUI;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.TwoDimension;
using TOW_Core.Abilities;
using TOW_Core.CharacterCreation;
using TOW_Core.Battle.StatusEffects;

namespace TOW_Core
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            TOWCommon.Say("TOW Core loaded.");
        }

        protected override void OnSubModuleLoad()
        {
            Harmony harmony = new Harmony("mod.harmony.theoldworld");
            harmony.PatchAll();
            ConfigureLogging();

            //This has to be here.
            AbilityManager.LoadAbilities();
            LoadAttributes();
            LoadStatusEffects();
            LoadSprites();
        }

        /// <summary>
        /// This is the main game start.
        /// </summary>
        /// <param name="game"></param>
        public override void BeginGameStart(Game game)
        {
            TOWTextManager.LoadAdditionalTexts();
            TOWTextManager.LoadTextOverrides();
            if(game.GameType.GetType() == typeof(CustomGame))
            {
                CustomBattleTroopManager.LoadCustomBattleTroops();
            }
            //LoadSprites();
        }

        private void LoadSprites()
        {
            UIResourceManager.SpriteData.SpriteCategories["tow_spritesheet"].Load(UIResourceManager.ResourceContext, UIResourceManager.UIResourceDepot);
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if(game.GameType is CustomGame)
            {
                gameStarterObject.Models.RemoveAllOfType(typeof(CustomBattleMoraleModel));
                gameStarterObject.AddModel(new TOWBattleMoraleModel());
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);
            mission.AddMissionBehaviour(new AttributeSystemMissionLogic());
            mission.AddMissionBehaviour(new StatusEffectMissionLogic());
            mission.AddMissionBehaviour(new Abilities.AbilityManagerMissionLogic());
            mission.AddMissionBehaviour(new Abilities.AbilityHUDMissionView());
            mission.AddMissionBehaviour(new Battle.FireArms.MusketFireEffectMissionLogic());
        }

        private void LoadAttributes()
        {
            AttributeManager attributeManager = new AttributeManager();
            attributeManager.LoadAttributes();
        }

        private void LoadStatusEffects()
        {
            StatusEffectManager effectManager = new StatusEffectManager();
            effectManager.LoadStatusEffects();
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