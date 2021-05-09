using System;
using System.Collections;
using System.Collections.Generic;

using TaleWorlds.Core;
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
        private Dictionary<int,float> _currentEffects;


        private float _damageValue;      //between 0 and infinite added at the end of a damage calculation of a hit
        private float _armorvalue;      //between 0 and infite added at the end of damage calculation of beeing hit
        private float _speedfactor;      //between 0 and a reasonable number(maybe 2) percentage of movement speed
        private float _staggering;
        private Timer _timer;

        

        public void InitializeStatusEffect(StatusEffect effect)
        {
            // TODO called at the beginning of mission by the StatusEffectManager fills all possible buffs and debuffs



            _statusEffectManager.NotifyStatusEffectTickObservers += OnTick;
        }
        

        private void  RunBuff(StatusEffect effect, float duration)
        {
            _currentEffects.Add(effect.id,duration);
        }

        public void OnTick(object sender, OnTickArgs args)
        {
           if(!_currentEffects.IsEmpty())
           {
               
               foreach (var key in _currentEffects.Keys)
               {
                   _currentEffects[key] = _currentEffects[key] - args.deltatime;

                   if (_currentEffects[key] < 0f)
                   {
                       if (_currentEffects.ContainsKey(key))
                       {
                           _statusEffects[key].active = false;
                       }
                       _currentEffects.Remove(key);
                   }
               }
           }
                
        }
    }
}