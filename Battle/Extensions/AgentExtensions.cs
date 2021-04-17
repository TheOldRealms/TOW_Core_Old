using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;
using TOW_Core.Utilities.Extensions;

namespace TOW_Core.Battle.Extensions
{
    public static class AgentAttributeExtensions
    {
        /// <summary>
        /// Maps all character IDs to a list of attributes for that character. For example, <"skeleton_warrior" <=> {"Expendable", "Undead"}>
        /// </summary>
        private static Dictionary<string, List<string>> CharacterIDToAttributeMap = new Dictionary<string, List<string>>();
        private static bool _attributesAreInitialized = false;

        public static bool IsExpendable(this Agent agent)
        {
            return agent.GetAttributes().Contains("Expendable");
        }

        /// <summary>
        /// Return all MoraleAgentComponents attached to the agent that are not of the base TaleWorlds implementation.
        /// </summary>
        /// <returns>A List of objects that subclass MoraleAgentComponent.</returns>
        public static List<MoraleAgentComponent> GetCustomMoraleComponents(this Agent agent)
        {
            List<MoraleAgentComponent> components = new List<MoraleAgentComponent>();
            List<AgentComponent> agentComponents = agent.Components
                .Where(component => component.GetType().IsSubclassOf(typeof(MoraleAgentComponent)) && component.GetType() != typeof(MoraleAgentComponent))
                .ToList();

            agentComponents.ForEach(component => components.AddIfNotNull(component as MoraleAgentComponent));

            return components;
        }

        public static List<MoraleAgentComponent> GetMoraleComponents(this Agent agent)
        {
            List<MoraleAgentComponent> components = agent.GetCustomMoraleComponents();
            components.AddIfNotNull(agent.GetComponent<MoraleAgentComponent>());
            return components;
        }

        public static List<string> GetAttributes(this Agent agent)
        {
            if (agent != null && agent.Character != null)
            {
                string characterName = agent.Character.StringId;

                List<string> attributeList;
                if (CharacterIDToAttributeMap.TryGetValue(characterName, out attributeList))
                {
                    return attributeList;
                }
            }
            return new List<string>();
        }

        public static void SetAttributesDictionary(Dictionary<string, List<string>> dict)
        {
            if(_attributesAreInitialized)
            {
                TOWCommon.Log("Attempted to set agent attributes dictionary, but it was already initialized.", LogLevel.Warn);
                return;
            }

            CharacterIDToAttributeMap = dict;
            _attributesAreInitialized = true;
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
            var blow = new Blow();
            blow.InflictedDamage = (int)damageAmount;
            agent.RegisterBlow(blow);
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
    }
}
