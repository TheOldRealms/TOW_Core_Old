using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    public class StatusEffectManager: MissionLogic
    {
        
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
        }
        //assigns all valid Statuseffect Option at the beginning of the Mission to Status effect Components residing on every agent

        public override MissionBehaviourType BehaviourType { get; }
        
       public EventHandler<OnTickArgs> NotifyStatusEffectTickObservers;
        public override void OnMissionTick(float dt)
        { 
            OnTickArgs arguments = new OnTickArgs() {deltatime = dt};
            NotifyStatusEffectTickObservers?.Invoke(this,arguments);
        }
        
    }



    public class OnTickArgs : EventArgs
    {
        public float deltatime;
    }
}