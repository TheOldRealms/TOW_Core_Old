using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class AttributeSystemManager
    {
        private static readonly AttributeSystemManager instance;
        
        private AttributeSystemManager(){}

        static AttributeSystemManager()
        {
            instance = new AttributeSystemManager();
        }
        public static AttributeSystemManager Instance => instance;
        
        public void InitalizeAttributes()
        {
            TOWCommon.Say("initalized");
            TOWCommon.Say("there are currently " + Campaign.Current.Parties.Count +" active Parties in the world");
            
            foreach (var party in Campaign.Current.MobileParties)
            {
                WorldMapAttribute worldMapAttribute = new WorldMapAttribute();
                worldMapAttribute.Initialize(party);
            }
        }



        public void Update()
        {
            TOWCommon.Say("there are currently " + Campaign.Current.Parties.Count +"active in the world");
        }
        
    }
}