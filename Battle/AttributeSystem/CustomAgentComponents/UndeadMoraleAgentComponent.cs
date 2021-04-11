using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Utilities;
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
            InitializeMorale();
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
            if (Morale < crumbleThreshold)
            {
                if (effectReady)
                {
                    float damageTaken = 5f;
                    damageTaken = MBMath.ClampFloat(damageTaken, 0, 5);
                    Agent.ApplyDamage(damageTaken);
                    crumbleTimer.Reset(MBCommon.GetTime(MBCommon.TimeType.Mission));
                    if (Agent.Health <= 0)
                    {
                        this.Agent.Die(new Blow());
                        this.Agent.FadeOut(false, false);
                    }
                }
            }
        }

        private void ApplyCrumbleDamage()
        {
            float damageTaken = 5f;
            damageTaken = MBMath.ClampFloat(damageTaken, 0, 5);
            Agent.ApplyDamage(damageTaken);
            crumbleTimer.Reset(MBCommon.GetTime(MBCommon.TimeType.Mission));
            if (Agent.Health <= 0)
            {
                Agent.Die(new Blow());
                Agent.FadeOut(false, false);
            }
        }

        private void ApplyMoraleRegen()
        {
            Agent.Heal(regenAmount);
        }

        private void InitializeMorale()
        {
            float num = 35f;
            int num2 = MBRandom.RandomInt(30);
            float num3 = num + num2;
            num3 = MissionGameModels.Current.BattleMoraleModel.GetEffectiveInitialMorale(Agent, num3);
            num3 = MBMath.ClampFloat(num3, 15f, 100f);
            Morale = num3;
        }

        private float GetDistributedTime(float deviation)
        {
            return MBCommon.GetTime(MBCommon.TimeType.Mission) - (float)TOWMath.GetRandomDouble(0, deviation);
        }
    }
}
