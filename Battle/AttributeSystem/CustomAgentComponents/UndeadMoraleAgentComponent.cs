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
    public class UndeadMoraleAgentComponent : MoraleAgentComponent
    {
        private Timer crumbleTimer;
        private bool effectReady = false;
        private float crumbleFrequencyInSeconds = 1f;
        private float regenAmount = 1f;
        private float crumbleThreshold = 10f;
        private float regenThreshold = 30f;

        public UndeadMoraleAgentComponent(Agent agent) : base(agent)
        {
            agent.RemoveComponentIfNotNull(agent.GetComponent<MoraleAgentComponent>());
        }

        protected override void Initialize()
        {
            base.Initialize();
            crumbleTimer = new Timer(GetDistributedTime(crumbleFrequencyInSeconds), crumbleFrequencyInSeconds, true);
        }

        protected override void OnTickAsAI(float dt)
        {
            effectReady = crumbleTimer.Check(MBCommon.GetTime(MBCommon.TimeType.Mission));

            if (effectReady)
            {
                if (Morale < crumbleThreshold)
                {
                    ApplyCrumbleDamage();
                }
                else if (Morale > regenThreshold)
                {
                    ApplyMoraleRegen();
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

        private void ApplyMoraleRegen()
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
