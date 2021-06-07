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
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Definition;
using TaleWorlds.SaveSystem.Load;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class AttributeSystemManager: CampaignBehaviorBase
    { 
    private bool isFilling;
    private Dictionary<string, WorldMapAttribute> _partyAttributes = new Dictionary<string, WorldMapAttribute>();

    private Action<float> deltaTime;

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
        CampaignEvents.OnBeforeSaveEvent.AddNonSerializedListener(this, OnGameSaving());
       // CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        CampaignEvents.OnNewGameCreatedPartialFollowUpEndEvent.AddNonSerializedListener(this,OnNewGameCreatedPartialFollowUpEnd);
        
       CampaignEvents.TickEvent.AddNonSerializedListener(this, deltaTime => TOWCommon.Say(deltaTime.ToString()));
    }

    private void OnGameLoaded()
    {
        TOWCommon.Say("save game restored with "+ _partyAttributes.Count + "parties in the dictionary");
    }
    
    private Action OnGameSaving()
    {
        
        return new Action(Action);
    }

    private void Action()
    {
        TOWCommon.Say("save game stored with "+ _partyAttributes.Count + "parties in the dictionary");
    }


    private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter campaignGameStarter)
    {
        InitalizeAttributes();
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