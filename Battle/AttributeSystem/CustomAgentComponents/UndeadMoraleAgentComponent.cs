using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;
using TOW_Core.Utilities;
using System.Timers;

namespace TOW_Core.Battle.AttributeSystem.CustomAgentComponents
{
    public class UndeadMoraleAgentComponent : AgentComponent
    {
        private float _crumbleFrequencyInSeconds = 1;
        private float _regenFrequencyInSeconds = 1;
        private float _deltaSinceLastRegenTick = 0;
        private float _deltaSinceLastCrumbleTick = 0;
        private float _regenAmount = 5f;
        private float _crumbleThreshold = 15f;
        private float _regenThreshold = 30f;
        private int _crumbleDamagePerInterval = 5;
        private bool _crumblingVisualsApplied;

        private CommonAIComponent _moraleComponent;

        public UndeadMoraleAgentComponent(Agent agent) : base(agent) { }

        protected override void Initialize()
        {
            base.Initialize();
            this._moraleComponent = Agent.GetComponent<CommonAIComponent>();
        }

        protected override void OnTickAsAI(float dt)
        {
            base.OnTickAsAI(dt);
            this._deltaSinceLastCrumbleTick += dt;
            this._deltaSinceLastRegenTick += dt;

            if (_moraleComponent.Morale < _crumbleThreshold && this._deltaSinceLastCrumbleTick > this._crumbleFrequencyInSeconds)
            {
                this._deltaSinceLastCrumbleTick = 0;
                try
                {
                    if (Agent.IsActive() || Agent.IsRetreating()) ApplyCrumbleDamage();
                }
                catch (Exception ex)
                {
                    TOWCommon.Log("Attempted to deal crumbledamage to agent. Error: " + ex.Message, NLog.LogLevel.Error);
                }
            }
            else if (_moraleComponent.Morale > _regenThreshold && this._deltaSinceLastRegenTick > this._regenFrequencyInSeconds)
            {
                _deltaSinceLastRegenTick = 0;
                ApplyRegenerationHealing();
            }
        }

        private void ApplyCrumbleDamage()
        {
            Agent.ApplyDamage(_crumbleDamagePerInterval);
            if (!_crumblingVisualsApplied)
            {
                _crumblingVisualsApplied = true;
                TOWParticleSystem.ApplyParticleToAgent(this.Agent, "undead_crumbling");
            }
        }

        private void ApplyRegenerationHealing()
        {
            Agent.Heal(_regenAmount);
        }
    }
} 
