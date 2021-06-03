using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.LinQuick;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class AttributeSystemManager: CampaignBehaviorBase
    { 
    private bool isFilling;
    private Dictionary<string, WorldMapAttribute> _partyAttributes = new Dictionary<string, WorldMapAttribute>();

    

    private async void Initialize()
    {
    }

    public static async void InitalizeAttributes(Game game, object obj)
    {
        
       
        /*
        TOWCommon.Say("initalizing");
        
       await Task.Run(() => GameManagerBase.Current.OnGameLoaded(game,obj));
       if (isFilling)
       {
           return;
       }
       isFilling = true;
        // CampaignEventDispatcher.Instance.OnMobilePartyCreated += CreatedParty;

        TOWCommon.Say("SaveGameLoaded");
        
        foreach (var party in Campaign.Current.MobileParties)
        {
            isFilling = true;
            WorldMapAttribute worldMapAttribute = new WorldMapAttribute();
            worldMapAttribute.id = party.Id.ToString();
            if (_partyAttributes.ContainsKey(party.Id.ToString()))
            {
                TOWCommon.Say("Found double!!!");
                continue;
            }
               
            //worldMapAttribute.id = party.Id.ToString();
            _partyAttributes.Add(worldMapAttribute.id, worldMapAttribute);
            //TOWCommon.Say(worldMapAttribute.id + " was add to the parties");
        }
        TOWCommon.Say("Finished adding");
        //  TOWCommon.Say("initalized");*/
    }
    




    public void CreatedParty(MobileParty party)
    {

    }


    public void RegisterParty(MobileParty party)
    {
        if (_partyAttributes.ContainsKey(party.Id.ToString()))
        {
            //potential check if the object pooled party is really from the same kind
            TOWCommon.Say("Already added");
            return;
        }
        else
        {
            
        }
        
    }

    private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
    {
       InitalizeAttributes();
    }
    
    
    public override void  RegisterEvents()
    {
        CampaignEvents.MobilePartyCreated.AddNonSerializedListener(this,RegisterParty);
        CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        CampaignEvents.OnNewGameCreatedPartialFollowUpEndEvent.AddNonSerializedListener(this,OnNewGameCreatedPartialFollowUpEnd);
    }

    private void OnPartySpawned(Hero obj)
    {
        throw new NotImplementedException();
    }

    private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter campaignGameStarter)
    {
        InitalizeAttributes();
    }

    private void InitalizeAttributes()
    {
        TOWCommon.Say("Initialize attributes");
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

    public override void SyncData(IDataStore dataStore)
    {
        dataStore.SyncData("_partyAttributes", ref _partyAttributes);
    }
    }
}