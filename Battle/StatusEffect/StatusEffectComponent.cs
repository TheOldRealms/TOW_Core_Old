using System;
using System.Collections;
using System.Collections.Generic;

using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    //resides on Each agent
    public class StatusEffectComponent: AgentComponent
    {
        public StatusEffectComponent(Agent agent) : base(agent)
        {
        }
        
        private StatusEffectManager _statusEffectManager;
        private Dictionary<int,StatusEffect> _statusEffects;
        private List<int> _currentEffects;
        
        private float _baseHealth; //to be assigned by the agent, will not be changed during mission
        private float _currentHealth;
        //TODO refine the active status values
        
            
        private float _bonusHealth;     //additional health on top of the base health. 
        private float _healthPercentage;
      
        private float _healthOverTime;  //all hots(heal over time) and dots(damge over time)  negative numbers resemble a dot.
        private List<DamageTypes> receivedDamageTypes; // all Damage types the agent suffers of.
        //armor related
        private float _WardSaveFactor;  // between 0 and 1 , 1 means full damage, 0 means 0 damage
        private float _armorvalue;      //between 0 and infite added at the end of damage calculation of beeing hit
        private float _armorPercentage; //percental 
        private List<DamageTypes> protectionTypes;
        
        //damage output
        private float _damageValue;      //between 0 and infinite added at the end of a damage calculation of a hit. base Damage
        private float _damagePercentage; //damage Percentage after all effects are added
        private List<DamageTypes> _attackDamageTypes;   //NOT FUNCTIONAL Implies all kind of damage types for an output attack
        
        
        //movement and agility
        private float _speedfactor;      //between 0 and a reasonable number(maybe 2) percentage of movement speed
        private float _staggering;
        
        
        



        public void InitializeStatusEffect(StatusEffect effect)
        {
            // TODO called at the beginning of mission by the StatusEffectManager fills all possible buffs and debuffs
            
        }
        

        private void  RunStatusEffect(StatusEffect effect)
        {
            if (_currentEffects.Contains(effect.id))
            {
                _statusEffects[effect.id]._currentduration =_statusEffects[effect.id].duration;
            }
            else
            {
                _currentEffects.Add(effect.id);
                UpdateEffects();
            }
            
        }
        
        protected override void  OnTickAsAI(float dt)
        {
           
        }
        public void OnTick(object sender, OnTickArgs args)
        {
            _currentHealth += _healthOverTime * args.deltatime; //TODO maybe check this somewhere different, but might make sense also here
            
            if(!_currentEffects.IsEmpty())
            {
                foreach (var key in _currentEffects)
                {
                    _statusEffects[key]._currentduration = _currentEffects[key] - args.deltatime;

                    if (_statusEffects[key]._currentduration<= 0f)
                    {
                        _statusEffects[key]._currentduration = _statusEffects[key].duration;
                        _currentEffects.Remove(key);
                        UpdateEffects();
                    }
                }
            }
        }


        private void UpdateEffects()
        {
            EffectContainer MergeContainer = new EffectContainer();
            foreach (var key in _statusEffects)
            {
                
                var container = key.Value.EffectContainer;
                switch (key.Value._EffectType)
                {
                    case StatusEffect.EffectType.Armor:
                        MergeContainer.Armorvalue+= container.Armorvalue;
                        MergeContainer.ArmorPercentage += container.ArmorPercentage;
                        MergeContainer.WardSaveFactor += container.WardSaveFactor;
                        break;
                    //... Health ... Damage
                }
            }

            _armorvalue = MergeContainer.Armorvalue;
            _armorPercentage = MergeContainer.ArmorPercentage;
            _WardSaveFactor = MergeContainer.WardSaveFactor;
            //... other effects 


            //TODO this is done once an status effect is added, or removed, it recalculates the fields which are included in the Damage Model
        }
    }
}