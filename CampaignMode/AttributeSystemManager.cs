using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.LinQuick;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;

namespace TOW_Core.CampaignMode
{
    public class AttributeSystemManager
    { 
    private bool isFilling;
    private static readonly AttributeSystemManager instance;
    private Dictionary<string, WorldMapAttribute> parties = new Dictionary<string, WorldMapAttribute>();

    private AttributeSystemManager()
    {
    }

    static AttributeSystemManager()
    {
        instance = new AttributeSystemManager();
        
    }

    public static AttributeSystemManager Instance => instance;


    private async void Initialize()
    {
    }

    public async void InitalizeAttributes(Game game, object obj)
    {
        
       
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
            if (parties.ContainsKey(party.Id.ToString()))
            {
                TOWCommon.Say("Found double!!!");
                continue;
            }
               
            //worldMapAttribute.id = party.Id.ToString();
            parties.Add(worldMapAttribute.id, worldMapAttribute);
            //TOWCommon.Say(worldMapAttribute.id + " was add to the parties");
        }
        TOWCommon.Say("Finished adding");
        //  TOWCommon.Say("initalized");
    }
    




    public void CreatedParty(MobileParty party)
    {

    }


    public void RegisterParty(MobileParty party)
    {
        if (parties.ContainsKey(party.Id.ToString()))
        {
            TOWCommon.Say("Already added");
        }



        //  TOWCommon.Say("party registered: " + party.Name  + " current number" + Campaign.Current.MobileParties.Count);
    }


    
    public void RegisterEvents()
    {
    }
    }
}