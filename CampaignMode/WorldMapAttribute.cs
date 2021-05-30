using System.Diagnostics;
using System.Runtime.CompilerServices;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.CampaignMode
{
    public class WorldMapAttribute : PartyComponent
    {
       
        internal void Initialize(MobileParty party)
        {
            this.OnInitialize();
            
            Utilities.TOWCommon.Say("hello im"+ party.Id);
        }
        
        private void UpdateArmorValue()
        {
            
        }


        public override TextObject Name { get; }
    }
}