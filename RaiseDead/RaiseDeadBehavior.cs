using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.GauntletUI.Data;


namespace TOW_Core
{
    class RaiseDeadBehavior
    {
        private static GauntletLayer layer;
        private static GauntletMovie gauntletMovie;
        private static RaiseDeadVM raiseDeadVM;

        private static GauntletLayer layer2;
        private static GauntletMovie gauntletMovie2;
        private static VCMapOverlayVM VCMapOverlayVM;

        public static void CreateRaiseDeadButton()
        {
            if (Game.Current != null && Game.Current.GameStateManager != null && Game.Current.GameStateManager.ActiveState != null && Game.Current.GameStateManager.ActiveState.GetType() == typeof(MapState) && !Game.Current.GameStateManager.ActiveState.IsMission && !Game.Current.GameStateManager.ActiveState.IsMenuState && Hero.MainHero.Culture.StringId == "khuzait" && layer2 == null && layer == null)
            {
                CreateVCMapOverlay();
            }
            else if(Game.Current.GameStateManager.ActiveState.GetType() != typeof(MapState) || Game.Current.GameStateManager.ActiveState.IsMission || Game.Current.GameStateManager.ActiveState.IsMenuState || Hero.MainHero.Culture.StringId != "khuzait")
            {
                DeleteOverlayVMLayer();
            }
        }

        private static void CreateVCMapOverlay()
        {
            try
            {
                if (layer2 != null)
                {
                    return;
                }
                layer2 = new GauntletLayer(1200);
                if (VCMapOverlayVM == null)
                {
                    VCMapOverlayVM = new VCMapOverlayVM();
                }
                gauntletMovie2 = (GauntletMovie)layer2.LoadMovie("VCMapOverlay", (ViewModel)VCMapOverlayVM);
                layer2.InputRestrictions.SetInputRestrictions();
                ScreenManager.TopScreen.AddLayer((ScreenLayer)layer2);
                layer2.IsFocusLayer = true;
                ScreenManager.TrySetFocus((ScreenLayer)layer2);
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(ex.ToString()));
                Console.WriteLine((object)ex);
            }
        }

        public static void DeleteOverlayVMLayer()
        {
            ScreenBase topScreen = ScreenManager.TopScreen;
            if (layer2 != null)
            {
                if (gauntletMovie2 != null)
                {
                    layer2.ReleaseMovie(gauntletMovie2);
                }
                topScreen.RemoveLayer((ScreenLayer)layer2);
            }
            layer2 = null;
            gauntletMovie2 = null;
        }

        public static void CreateVMLayer()
        {
            try
            {
                if (layer != null)
                {
                    return;
                }
                layer = new GauntletLayer(1000);
                if (raiseDeadVM == null)
                {
                    raiseDeadVM = new RaiseDeadVM();
                }
                raiseDeadVM.UpdateValues();
                gauntletMovie = (GauntletMovie) layer.LoadMovie("RaiseDead", (ViewModel)raiseDeadVM);
                layer.InputRestrictions.SetInputRestrictions();
                ScreenManager.TopScreen.AddLayer((ScreenLayer)layer);
                layer.IsFocusLayer = true;
                ScreenManager.TrySetFocus((ScreenLayer)layer);
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(ex.ToString()));
                Console.WriteLine((object)ex);
            }
        }

        public static void DeleteVMLayer()
        {
            ScreenBase topScreen = ScreenManager.TopScreen;
            if (layer != null)
            {
                if (gauntletMovie != null)
                {
                    layer.ReleaseMovie(gauntletMovie);
                }
                topScreen.RemoveLayer((ScreenLayer)layer);
            }
            layer = null;
            gauntletMovie = null;
        }
    }
}
