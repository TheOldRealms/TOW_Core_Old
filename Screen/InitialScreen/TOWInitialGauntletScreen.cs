
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.GauntletUI;
using TaleWorlds.MountAndBlade.View.Screen;

using TOW_Core.Screen.InitialScreen;

namespace TOW_Core.Screen
{
    [GameStateScreen(typeof(InitialState))]
    public class TOWInitialGauntletScreen : InitialGauntletScreen
    {
        private GauntletLayer _gauntletLayer;
        private TOWInitialScreenVM _dataSource;

        public TOWInitialGauntletScreen(InitialState state) : base(state)
        {

            this._dataSource = new TOWInitialScreenVM("BUTTON TEXT", () => InformationManager.DisplayMessage(new InformationMessage("Hello World!")));
            this._gauntletLayer = new GauntletLayer(3, "GauntletLayer");
            this._gauntletLayer.LoadMovie("TOWInitialScreenOverlay", this._dataSource);

            this._gauntletLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.Mouse);

            base.AddLayer(this._gauntletLayer);
        }
    }
}
