using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;

namespace TOW_Core.Abilities
{
    public class AbilityManagerMissionLogic : MissionLogic
    {
        public AbilityManagerMissionLogic() { }

        public override void OnMissionTick(float dt)
        {
            base.OnMissionTick(dt);
            if (Mission.CurrentState == Mission.State.Continuing)
            {
                if (Input.IsKeyPressed(InputKey.Q))
                {
                    Agent.Main.CastCurrentAbility();
                }
            }
        }

        public override void OnAgentCreated(Agent agent)
        {
            base.OnAgentCreated(agent);
            //always add it for the main agent
            if(agent == Agent.Main) agent.AddComponent(new AbilityComponent(agent));
            //add it to all other units (like heroes, lords) that we can define in the attributes xml
            if (agent.IsAbilityUser()) agent.AddComponent(new AbilityComponent(agent));
        }
    }
}
