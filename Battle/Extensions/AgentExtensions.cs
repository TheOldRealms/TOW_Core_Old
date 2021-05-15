using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;
using TOW_Core.Abilities;
using TOW_Core.Utilities;
using TOW_Core.Utilities.Extensions;

namespace TOW_Core.Battle.Extensions
{
    public static class AgentExtensions
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

        public static bool IsUndead(this Agent agent)
        {
            return agent.GetAttributes().Contains("Undead");
        }

        public static bool IsAbilityUser(this Agent agent)
        {
            return agent.GetAttributes().Contains("AbilityUser");
        }

        public static void CastCurrentAbility(this Agent agent)
        {
            var abilitycomponent = agent.GetComponent<AbilityComponent>();
            if(abilitycomponent != null)
            {
                if(abilitycomponent.CurrentAbility != null) abilitycomponent.CurrentAbility.Use(agent);
            }
        }

        public static BaseAbility GetCurrentAbility(this Agent agent)
        {
            var abilitycomponent = agent.GetComponent<AbilityComponent>();
            if (abilitycomponent != null)
            {
                return abilitycomponent.CurrentAbility;
            }
            else return null;
        }

        public static void SelectNextAbility(this Agent agent)
        {
            var abilitycomponent = agent.GetComponent<AbilityComponent>();
            if (abilitycomponent != null)
            {
                abilitycomponent.SelectNextAbility();
            }
        }

        public static void SelectAbility(this Agent agent, int abilityindex)
        {
            var abilitycomponent = agent.GetComponent<AbilityComponent>();
            if (abilitycomponent != null)
            {
                abilitycomponent.SelectAbility(abilityindex);
            }
        }

        public static List<string> GetAbilities(this Agent agent)
        {
            return AbilityManager.GetAbilitesForCharacter(agent.Character.StringId);
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
        public static void ApplyDamage(this Agent agent, int damageAmount, Agent damager = null)
        {
            try
            {
                var blow = new Blow();
                blow.InflictedDamage = damageAmount;
                if(damager != null) blow.OwnerId = damager.Index;
                if(agent.State == TaleWorlds.Core.AgentState.Active || agent.State == TaleWorlds.Core.AgentState.Routed)
                agent.RegisterBlow(blow);
            }
            catch(Exception e)
            {
                TOWCommon.Log("Applydamange: attempted to damage agent, but: " + e.Message, NLog.LogLevel.Error);
            }
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
