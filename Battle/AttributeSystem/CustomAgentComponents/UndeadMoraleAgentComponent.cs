using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;
using TOW_Core.Utilities;

namespace TOW_Core.Battle.AttributeSystem.CustomAgentComponents
{
    public class UndeadMoraleAgentComponent : AgentComponent
    {
        private Timer crumbleTimer;
        private bool effectReady = false;
        private float crumbleFrequencyInSeconds = 1f;
        private float regenAmount = 5f;
        private float crumbleThreshold = 15f;
        private float regenThreshold = 30f;
        private bool _iscrumbling = false;
        private MoraleAgentComponent _moraleComponent;

        public UndeadMoraleAgentComponent(Agent agent) : base(agent) { }

        private delegate void StartedCrumblingEventHandler();
        private event StartedCrumblingEventHandler StartedCrumbling;
        private bool IsCrumbling {
            get
            {
                return _iscrumbling;
            }
            set
            {
                if (value == true) StartedCrumbling?.Invoke();
                _iscrumbling = value;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            this._moraleComponent = Agent.GetComponent<MoraleAgentComponent>();
            crumbleTimer = new Timer(GetDistributedTime(crumbleFrequencyInSeconds), crumbleFrequencyInSeconds, true);
            this.StartedCrumbling += UndeadMoraleAgentComponent_StartedCrumbling;
        }

        private void UndeadMoraleAgentComponent_StartedCrumbling()
        {
            TOWParticleSystem.ApplyParticleToAgent(this.Agent, "undead_crumbling");
        }

        protected override void OnTickAsAI(float dt)
        {
            base.OnTickAsAI(dt);
            effectReady = crumbleTimer.Check(MBCommon.GetTime(MBCommon.TimeType.Mission));

            if (effectReady)
            {
                if (_moraleComponent.Morale < crumbleThreshold)
                {
                    if (!IsCrumbling) IsCrumbling = true;
                    ApplyCrumbleDamage();
                }
                else if (_moraleComponent.Morale > regenThreshold)
                {
                    ApplyRegenerationHealing();
                }
            }
        }

        private void ApplyCrumbleDamage()
        {
            float damageTaken = 5f;
            damageTaken = MBMath.ClampFloat(damageTaken, 0, 5);
            Agent.ApplyDamage(damageTaken);
            crumbleTimer.Reset(MBCommon.GetTime(MBCommon.TimeType.Mission));
        }

        private void ApplyRegenerationHealing()
        {
            Agent.Heal(regenAmount);
            crumbleTimer.Reset(MBCommon.GetTime(MBCommon.TimeType.Mission));
        }

        private float GetDistributedTime(float deviation)
        {
            return MBCommon.GetTime(MBCommon.TimeType.Mission) - (float)TOWMath.GetRandomDouble(0, deviation);
        }
    }
} 
