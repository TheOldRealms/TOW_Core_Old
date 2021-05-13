using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using System.Timers;
using Messages.FromClient.ToLobbyServer;
using Timer = System.Timers.Timer;

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
        private List<int> _currentEffects = new List<int>();
        
        //TODO refine the active status and passive values
        // base values - passiv values, include raw values of the unit as well as campaign map modifications by perks and 
        private float _baseHealth; //to be assigned by the agent, will not be changed during mission
        private float _currentHealth;
        
        
        //health related    
        private float _bonusHealth;     //additional health on top of the base health. 
        private float _healthPercentage;
        private float _healthOverTime;  //all hots(heal over time) and dots(damge over time)  negative numbers resemble a dot.
        
        private List<DamageTypes> receivedDamageTypes; // all Damage types the agent suffers of.
        //armor related
        private float _WardSaveFactor;  // between 0 and 1 , 1 means full damage, 0 means 0 damage
        private float _armorvalue;      //between 0 and infite added at the end of damage calculation of beeing hit
        private float _armorPercentage; //additonal percental value on top of the resulting armor value 
        private List<DamageTypes> protectionTypes;
        
        //damage output
        private float _damageValue;      //between 0 and infinite added at the end of a damage calculation of a hit. base Damage
        private float _damagePercentage; //damage Percentage after all effects are added
        private List<DamageTypes> _attackDamageTypes;   //NOT FUNCTIONAL Implies all kind of damage types for an output attack
        
        
        //movement and agility
        private float _speedfactor;      //between 0 and a reasonable number(maybe 2) percentage of movement speed
        private float _staggering;

        private float testupdate=0f;
        private int counter;
        private Timer _timer;

        private EventHandler<ElapsedEventArgs> NotifyOnIternalTimerTickCall;

        public void InitializeStatusEffect(StatusEffect effect)
        {
            
            if (_statusEffects == null)
            {
                _statusEffects = new Dictionary<int, StatusEffect>();
                _statusEffects.Add(effect.id, effect);
            }
            else
            {
                foreach (var idKey in _statusEffects.Keys)
                {
                    if (effect.id == idKey)
                    {
                        effect.id++;        //testing purpose
                        effect.duration += 5;
                    }
                }
                try
                {
                    _statusEffects.Add(effect.id,effect);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Key" + effect.id + "already exists.");
                }
                
            }
            
            // TODO called at the beginning of mission by the StatusEffectManager fills all possible buffs and debuffs

            
            //TODO all active perks or skill values need also to be assigned here aswell to base values 


            _timer = new Timer(1000f);
            this._timer.Elapsed += TimerTick;
            NotifyOnIternalTimerTickCall=OnTick;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            
            
            //Mission.Current.GetMissionBehaviour<StatusEffectManager>().NotifyStatusEffectTickObservers += OnTick;
            if(Agent.IsPlayerControlled)
                TOW_Core.Utilities.TOWCommon.Say("initialized");
            
        }
        

        public void  RunStatusEffect(int id)
        {
            //TOW_Core.Utilities.TOWCommon.Say("Run effect " + id);
            if (_currentEffects.Contains(id))
            {
                _statusEffects[id]._currentduration =_statusEffects[id].duration;
            }
            else
            {
               // TOW_Core.Utilities.TOWCommon.Say("...Add effect " + id);
                _currentEffects.Add(id);
                UpdateEffects();
            }
            
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            
            if (sender == this._timer)
            {
                NotifyOnIternalTimerTickCall?.Invoke(this,e); 
            }
            else
            {
                //deregister the listener of the sender
            }
            
        } 
        
        public void OnTick(object sender, ElapsedEventArgs e)
        {
            testupdate += 1;
            
            if (testupdate >= 10f)
            {
                counter += 1;
                
                testupdate = 0f;
                
                    RunStatusEffect(0);
                    RunStatusEffect(1);
                    RunStatusEffect(2);
                    RunStatusEffect(3);
                    RunStatusEffect(4);
                    RunStatusEffect(5);
                    RunStatusEffect(6);
                    RunStatusEffect(7);
                    RunStatusEffect(8);
            }
            
            if(!_currentEffects.IsEmpty())
            {
               // TOW_Core.Utilities.TOWCommon.Say("... timeupdate for " + _currentEffects.Count);
                for (int i=0;i<_currentEffects.Count;i++)
                {
                    _statusEffects[_currentEffects[i]]._currentduration -= 1;

                    if (_statusEffects[_currentEffects[i]]._currentduration <= _statusEffects[_currentEffects[i]].duration / 2f)
                    {
                        if (Agent == Agent.Main)
                        {
                            TOW_Core.Utilities.TOWCommon.Say("50% of time of " + _currentEffects[i] + "went off");
                        }
                    }

                    if (_statusEffects[_currentEffects[i]]._currentduration<= 0f)
                    {

                        _statusEffects[_currentEffects[i]]._currentduration = _statusEffects[_currentEffects[i]].duration;
                        _currentEffects.Remove(_currentEffects[i]);
                        if (Agent == Agent.Main)
                        {
                            TOW_Core.Utilities.TOWCommon.Say( "removed " + " "+  _currentEffects[i]);
                        }
                        
                        UpdateEffects();
                        
                    }
                }
                //TOW_Core.Utilities.TOWCommon.Say(Agent.Name+"listen to"+ sender.GetHashCode()+ "armor value "  + _armorvalue.ToString()+ "  " + counter.ToString());
                //_currentHealth += _healthOverTime * args.deltatime; //TODO maybe check this somewhere different, but might make sense also here
            }
            
            
        }


        private void UpdateEffects()
        {
           // TOW_Core.Utilities.TOWCommon.Say("...Update Effect " );
            EffectContainer MergeContainer = new EffectContainer();
            for (int i=0;i<_currentEffects.Count;i++ )
            {
               // TOW_Core.Utilities.TOWCommon.Say("..." + _currentEffects[i] + " is Effect type of " +_statusEffects[_currentEffects[i]]._EffectType.ToString());
                var container = _statusEffects[_currentEffects[i]].EffectContainer;
                
                switch ( _statusEffects[_currentEffects[i]]._EffectType)
                {
                    case StatusEffect.EffectType.Armor:
                        
                        MergeContainer.Armorvalue+= container.Armorvalue;
                        MergeContainer.ArmorPercentage += container.ArmorPercentage;
                        MergeContainer.WardSaveFactor += container.WardSaveFactor;
                        break;
                    case StatusEffect.EffectType.Damage:
                        break;
                    case StatusEffect.EffectType.Health:
                        break;
                    
                    //... Health ... Damage
                }
            }

            _armorvalue = MergeContainer.Armorvalue;
            _armorPercentage = MergeContainer.ArmorPercentage;
            _WardSaveFactor = MergeContainer.WardSaveFactor;
            
           
            //... other effects 
            if (Agent == Agent.Main)
            {
                TOW_Core.Utilities.TOWCommon.Say("updatated" + Agent.Name + " " + _armorvalue.ToString());
            }
            // TOW_Core.Utilities.TOWCommon.Say("Status Effects are updated");

            //TODO this is done once an status effect is added, or removed, it recalculates the fields which are included in the Damage Model
        }
    }
}