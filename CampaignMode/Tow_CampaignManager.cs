using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    
    public  class Tow_CampaignManager
    {
        public static readonly Tow_CampaignManager instance;
        
        private Tow_CampaignManager(){}

        static Tow_CampaignManager()
        {
            instance = new Tow_CampaignManager();
        }
        public static Tow_CampaignManager Instance => instance;



        public void Hello()
        {
            Utilities.TOWCommon.Say("Hello");
        }
        
        
        
    }
}