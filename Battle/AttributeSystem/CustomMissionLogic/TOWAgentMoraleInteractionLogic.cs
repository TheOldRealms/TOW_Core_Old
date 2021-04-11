using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.AttributeSystem.CustomAgentComponents;
using TOW_Core.Battle.Utilities;

namespace TOW_Core.Battle.AttributeSystem.CustomMissionLogic
{
    public class TOWAgentMoraleInteractionLogic : MissionLogic
    {
        public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
        {
            if (affectedAgent.Character != null && (affectorAgent != null ? affectorAgent.Character : null) != null && (agentState == AgentState.Killed || agentState == AgentState.Unconscious) && affectedAgent.Team != null)
            {
                ValueTuple<float, float> valueTuple = MissionGameModels.Current.BattleMoraleModel.CalculateMoraleChangeAfterAgentKilled(affectedAgent, affectorAgent, WeaponComponentData.GetRelevantSkillFromWeaponClass((WeaponClass)killingBlow.WeaponClass));
                float item = valueTuple.Item1;
                float item2 = valueTuple.Item2;
                if (item == 0f && item2 == 0f)
                {
                    return;
                }
                ApplyAoeMoraleEffect(affectedAgent, affectedAgent.GetWorldPosition(), affectorAgent.GetWorldPosition(), affectedAgent.Team, item, item2, 10f, null, null);
            }
        }

        public void ApplyAoeMoraleEffect(Agent affectedAgent, WorldPosition affectedAgentPosition, WorldPosition affectorAgentPosition, Team affectedAgentTeam, float moraleChangeAffected, float moraleChangeAffector, float radius, Predicate<Agent> affectedCondition = null, Predicate<Agent> affectorCondition = null)
        {
            if (AgentIsExpendable(affectedAgent)) return;

            IEnumerable<Agent> nearbyAgents = Mission.GetNearbyAgents(affectedAgentPosition.AsVec2, radius);

            int num = 10;
            int num2 = 10;
            foreach (Agent agent in nearbyAgents)
            {
                BasicCharacterObject character = agent.Character;
                BasicCultureObject culture = character != null ? character.Culture : null;
                string cultureStringId = culture != null ? culture.StringId : null;
                if (agent.Team != null)
                {
                    float num3 = agent.GetWorldPosition().GetNavMeshVec3().Distance(affectedAgentPosition.GetNavMeshVec3());
                    if (num3 < radius && agent.IsAIControlled)
                    {
                        if (agent.Team.IsEnemyOf(affectedAgentTeam))
                        {
                            if (num > 0 && (affectorCondition == null || affectorCondition(agent)))
                            {
                                float delta = MissionGameModels.Current.BattleMoraleModel.CalculateMoraleChangeToCharacter(agent, moraleChangeAffector, num3);
                                agent.GetCustomMoraleComponents().ForEach(component =>
                                {
                                    if (component != null)
                                    {
                                        component.Morale += delta;
                                    }
                                });
                                num--;
                            }
                        }
                        else if (num2 > 0 && (affectedCondition == null || affectedCondition(agent)))
                        {
                            float delta2 = MissionGameModels.Current.BattleMoraleModel.CalculateMoraleChangeToCharacter(agent, moraleChangeAffected, num3);
                            agent.GetCustomMoraleComponents().ForEach(component =>
                            {
                                if (component != null)
                                {
                                    component.Morale += delta2;
                                }
                            });
                            num2--;
                        }
                    }
                }
            }
        }

        private bool AgentIsExpendable(Agent agent)
        {
            if (agent != null)
            {
                if (AttributeManager.Instance.GetAttributes(agent).Contains("Expendable"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
