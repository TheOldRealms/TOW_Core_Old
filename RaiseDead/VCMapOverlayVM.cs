using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem;
using System;

namespace TOW_Core
{
    class VCMapOverlayVM : ViewModel
    {
        public void Click() {
            RaiseDeadBehavior.DeleteOverlayVMLayer();
            RaiseDeadBehavior.CreateVMLayer();
        }
    }
}
