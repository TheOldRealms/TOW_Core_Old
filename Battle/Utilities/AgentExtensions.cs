using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.AttributeSystem;
using TOW_Core.Utilities.Extensions;

namespace TOW_Core.Battle.Utilities
{
    public static class AgentExtensions
    {
        public static List<MoraleAgentComponent> GetCustomMoraleComponents(this Agent agent)
        {
            List<MoraleAgentComponent> components = new List<MoraleAgentComponent>();
            List<AgentComponent> agentComponents = agent.Components
                .Where(component => component.GetType().IsSubclassOf(typeof(MoraleAgentComponent)) && component.GetType() != typeof(MoraleAgentComponent))
                .ToList();

            agentComponents.ForEach(component => components.AddIfNotNull(component as MoraleAgentComponent));

            return components;
        }

        public static void RemoveComponentIfNotNull(this Agent agent, AgentComponent component)
        {
            if (component != null)
            {
                agent.RemoveComponent(component);
            }
        }

        /// <summary>
        /// Apply damage to an agent. 
        /// </summary>
        /// <param name="agent">The agent that will be damaged</param>
        /// <param name="damageAmount">How much damage the agent will receive.</param>
        public static void ApplyDamage(this Agent agent, float damageAmount)
        {
            //Prevent reduction below 0 health (possibly unnecessary)
            agent.Health = Math.Max(agent.Health - damageAmount, 0);
        }

        /// <summary>
        /// Apply healing to an agent.
        /// </summary>
        /// <param name="agent">The agent that will be healed</param>
        /// <param name="healingAmount">How much healing the agent will receive</param>
        public static void Heal(this Agent agent, float healingAmount)
        {
            //Cap healing at the agent's max hit points
            agent.Health = Math.Min(agent.Health + healingAmount, agent.HealthLimit);
        }

        public static List<string> GetAttributes(this Agent agent)
        {
            return AttributeManager.Instance.GetAttributes(agent);
        }
    }
}
