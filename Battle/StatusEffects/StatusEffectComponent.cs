using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using Messages.FromClient.ToLobbyServer;
using TOW_Core.Utilities;
using TOW_Core.Battle.Extensions;
using TaleWorlds.Engine;
using System.Linq;

namespace TOW_Core.Battle.StatusEffects
{
    public class StatusEffectComponent: AgentComponent
    {
        private float _updateFrequency = 1;
        private float _deltaSinceLastTick = 0;
        private HashSet<StatusEffect> _currentEffects;
        private EffectAggregate _effectAggregate;

        public StatusEffectComponent(Agent agent) : base(agent)
        {
            _currentEffects = new HashSet<StatusEffect>();
            _effectAggregate = new EffectAggregate(); 
        }

        public void RunStatusEffect(string id)
        {
            if(Agent == null)
                return;

            StatusEffect effect = _currentEffects.Where(e => e.Id.Equals(id)).FirstOrDefault();
            if (effect != null)
            {
                effect.ResetDuration();
            }
            else
            {
                effect = StatusEffectManager.GetStatusEffect(id);
                AddEffect(effect);
            }
        }

        public void OnElapsed(float dt)
        {
            foreach (StatusEffect effect in _currentEffects.ToList())
            {
                effect.CurrentDuration -= dt;

                if (effect.CurrentDuration <= 0f)
                {
                    effect.CurrentDuration = effect.Duration;
                    RemoveEffect(effect);
                }
            }

            //Temporary method for applying effects from the aggregate. This needs to go to a damage manager/calculator which will use the 
            //aggregated information to determine how much damage to apply to the agent
            if (_effectAggregate.HealthOverTime != 0 && Agent.IsActive() && Agent != null)
            {
                Agent.ApplyDamage(-1 * ((int)_effectAggregate.HealthOverTime), Agent);
            }
        }
        
        public void OnTick(object sender, OnTickArgs e)
        {
            float dt = e.deltatime;
            _deltaSinceLastTick += dt;
            if(_deltaSinceLastTick > _updateFrequency)
            {
                _deltaSinceLastTick = 0;
                OnElapsed(dt);
            }
        }

        private void RemoveEffect(StatusEffect effect)
        {
            _currentEffects.Remove(effect);
            effect.Particles = null;
            _effectAggregate.RemoveEffect(effect);
        }

        private void AddEffect(StatusEffect effect)
        {
            _currentEffects.Add(effect);
            effect.Particles = TOWParticleSystem.ApplyParticleToAgent(Agent, effect.ParticleId, effect.ParticleIntensity);
            _effectAggregate.AddEffect(effect);
        }

        private class EffectAggregate
        {
            public float HealthOverTime { get; set; } = 0;
            public float WardSaveFactor { get; set; } = 0;
            public float FlatArmorEffect { get; set; } = 0;
            public float PercentageArmorEffect { get; set; } = 0;
            public float FlatDamageEffect { get; set; } = 0;
            public float PercentageDamageEffect { get; set; } = 0;

            public void AddEffect(StatusEffect effect)
            {
                switch (effect.Type)
                {
                    case StatusEffect.EffectType.Armor:
                        FlatArmorEffect += effect.FlatArmorEffect;
                        PercentageArmorEffect += effect.PercentageArmorEffect;
                        WardSaveFactor += effect.WardSaveFactor;
                        break;
                    case StatusEffect.EffectType.Damage:
                        FlatDamageEffect += effect.FlatDamageEffect;
                        PercentageDamageEffect += effect.PercentageDamageEffect;
                        break;
                    case StatusEffect.EffectType.Health:
                        HealthOverTime += effect.HealthOverTime;
                        break;
                }
            }

            public void RemoveEffect(StatusEffect effect)
            {
                switch (effect.Type)
                {
                    case StatusEffect.EffectType.Armor:
                        FlatArmorEffect -= effect.FlatArmorEffect;
                        PercentageArmorEffect -= effect.PercentageArmorEffect;
                        WardSaveFactor -= effect.WardSaveFactor;
                        break;
                    case StatusEffect.EffectType.Damage:
                        FlatDamageEffect -= effect.FlatDamageEffect;
                        PercentageDamageEffect -= effect.PercentageDamageEffect;
                        break;
                    case StatusEffect.EffectType.Health:
                        HealthOverTime -= effect.HealthOverTime;
                        break;
                }
            }
        }
    }
}