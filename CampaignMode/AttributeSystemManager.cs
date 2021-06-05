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
        if (!_partyAttributes.ContainsKey(party.Party.Id.ToString()))
        {
            WorldMapAttribute attribute = new WorldMapAttribute {id = party.Id.ToString()};
            _partyAttributes.Add(attribute.id, attribute);
            //potential check if the object pooled party is really from the same kind
            TOWCommon.Say("added new party : " + attribute.id); 
            return;
        }
        else
        {
            TOWCommon.Say("Already added"); 
        }
        
    }

    public void DeRegisterParty(MobileParty party, PartyBase partyBase)
    {
        if(_partyAttributes.ContainsKey(party.Id.ToString()))
        {
            _partyAttributes.Remove(party.ToString());
            TOWCommon.Say("Removed + " + party.Id.ToString()); 
        }
    }

    private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
    {
        InitalizeAttributes();
    }
    
    
    
    
    public override void  RegisterEvents()
    {
        
        CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener(this, OnGameLoaded);
        //CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        CampaignEvents.MobilePartyCreated.AddNonSerializedListener(this,RegisterParty);
        CampaignEvents.MobilePartyDestroyed.AddNonSerializedListener(this,DeRegisterParty);
       // CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        CampaignEvents.OnNewGameCreatedPartialFollowUpEndEvent.AddNonSerializedListener(this,OnNewGameCreatedPartialFollowUpEnd);
    }

    private void OnGameLoaded()
    {
        InitalizeAttributes();
    }

  

    private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter campaignGameStarter)
    {
       // InitalizeAttributes();
    }

    private void InitalizeAttributes()
    {
        var parties = Campaign.Current.MobileParties;
        TOWCommon.Say("Initialize attributes" + Campaign.Current.MobileParties.Count);
        
        foreach (MobileParty party in parties)
        {
            
            TOWCommon.Say(party.Party.Id);
            if (_partyAttributes.ContainsKey(party.Id.ToString()))
            {
                TOWCommon.Say(party.Id.ToString()+  " was already there");
                continue;
            }
            WorldMapAttribute attribute = new WorldMapAttribute();
            attribute.id = party.Id.ToString();
            attribute.Leader = party.LeaderHero;
        
            _partyAttributes.Add(attribute.id, attribute);
            
            
        }
        TOWCommon.Say(_partyAttributes.Count + "of "+  parties.Count+ " were initalized");
    }

    public override void SyncData(IDataStore dataStore)
    {
        dataStore.SyncData("_partyAttributes", ref _partyAttributes);
    }
    }
}