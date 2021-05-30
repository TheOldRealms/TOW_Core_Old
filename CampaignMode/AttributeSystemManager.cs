﻿using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.LinQuick;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class AttributeSystemManager
    {
        private static readonly AttributeSystemManager instance;
        //private Dictionary<MobileParty> parties = new List<MobileParty>();
        
        private AttributeSystemManager(){}

        static AttributeSystemManager()
        {
            instance = new AttributeSystemManager();
        }
        public static AttributeSystemManager Instance => instance;
        
        public void InitalizeAttributes()
        {
           // CampaignEventDispatcher.Instance.OnMobilePartyCreated += CreatedParty;
            
            TOWCommon.Say("initalized");
           
            
            foreach (var party in Campaign.Current.MobileParties)
            {
                WorldMapAttribute worldMapAttribute = new WorldMapAttribute();
                worldMapAttribute.Initialize(party);
            }
            TOWCommon.Say("there are currently " + Campaign.Current.Parties.Count +" active Parties in the world with active WorldMapAttribute");
        }


        public void CreatedParty(MobileParty party)
        {
            
        }


        public void RegisterParty(MobileParty party)
        {
            if (Campaign.Current.MobileParties.Contains(party))
            {
                
                TOWCommon.Say("party already existed");

                return;
            }
            
            
            
            TOWCommon.Say("party registered: " + party.Name  + " current number" + Campaign.Current.MobileParties.Count);
        }



        public void Update()
        {
            TOWCommon.Say("there are currently " + Campaign.Current.Parties.Count +"active in the world");
        }
        
    }
}