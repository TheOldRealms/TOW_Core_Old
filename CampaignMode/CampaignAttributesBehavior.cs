using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class CampaignAttributesBehavior : CampaignBehaviorBase
    {
        private Dictionary<string, WorldMapAttribute> _partyAttributes = new Dictionary<string, WorldMapAttribute>();

        public override void RegisterEvents()
        {
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnGameLoaded));
            CampaignEvents.OnNewGameCreatedPartialFollowUpEndEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnNewGameCreatedPartialFollowUpEnd));
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_partyAttributes", ref _partyAttributes);
        }

        private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            foreach(WorldMapAttribute attribute in _partyAttributes.Values)
            {
                TOWCommon.Say("Loaded attribute for party with leader " + attribute.Leader.Name.ToString());
            }
        }

        private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter campaignGameStarter)
        {
            int id = 0;
            foreach (MobileParty party in Campaign.Current.MobileParties)
            {
                if (party.IsLordParty)
                {
                    WorldMapAttribute attribute = new WorldMapAttribute(id++.ToString());
                    attribute.Leader = party.LeaderHero;
                    attribute.id = (id++).ToString();
                    _partyAttributes.Add(party.Id.ToString(), attribute);
                }
            }
        }
    }

    public class CampaignAttributeDefiner : SaveableTypeDefiner
    {
        public CampaignAttributeDefiner() : base(1_543_132) { }
        protected override void DefineClassTypes()
        {
            base.DefineClassTypes();
            AddClassDefinition(typeof(WorldMapAttribute), 1);
        }

        protected override void DefineContainerDefinitions()
        {
            base.DefineContainerDefinitions();
            ConstructContainerDefinition(typeof(Dictionary<string, WorldMapAttribute>));
        }
    }
}
