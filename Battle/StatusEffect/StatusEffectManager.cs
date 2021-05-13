using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Win32;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    public class StatusEffectManager: MissionLogic
    {
        private List<Agent> Agents =new List<Agent>();
        public override MissionBehaviourType BehaviourType { get; }
        
        public EventHandler<ElapsedEventArgs> NotifyStatusEffectTickObservers;
        
        public static Timer Timer; 
        public override void OnCreated()
        {
            Timer = new Timer(1000f) {AutoReset = true, Enabled = true};
            Timer.Elapsed += OnTimeElasped;
        }

        public override void OnAgentCreated(Agent agent)
        {
            base.OnAgentCreated(agent);
            //always add it for the main agent
            agent.AddComponent(new StatusEffectComponent(agent));
            //add it to all other units (like heroes, lords) that we can define in the attributes xml
            
            // initialization status effect test
            var testList = new List<StatusEffect>();
            StatusEffect testStatusEffect = new StatusEffect
            {
                id = 1,
                duration = 5f,
                _currentduration = 5f,
                _EffectType = StatusEffect.EffectType.Armor,
                active = false,
                affector = null,
                EffectContainer = new EffectContainer
                {
                    _healthOverTime = 0,
                    receivedDamageTypes = null,
                    Armorvalue = -50f,
                    ArmorPercentage = 15,
                    _damageValue = 0,
                    _damagePercentage = 0,
                    _attackDamageTypes = null,
                    WardSaveFactor = 1f
                }
            };
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            testList.Add(testStatusEffect);
            
            testList.ForEach(statusEffect => agent.GetComponent<StatusEffectComponent>().InitializeStatusEffect(statusEffect));
            Agents.Add(agent);
            
        }
        //assigns all valid Statuseffect Option at the beginning of the Mission to Status effect Components residing on every agent


        public void OnTimeElasped(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if(!TaleWorlds.Core.Extensions.IsEmpty(Agents))
                Utilities.TOWCommon.Say(Agents.Count.ToString());
            NotifyStatusEffectTickObservers?.Invoke(this,elapsedEventArgs);
        }
       
        
        
    }
    

    public class OnTickArgs : EventArgs
    {
        
        
        
        public float deltatime;
    }
}