using NLog;
using System;
using System.Collections.Generic;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;
using TOW_Core.Utilities;

namespace TOW_Core.Abilities
{
    public class AbilityComponent : AgentComponent
    {
        private BaseAbility _currentAbility = null;
        private List<BaseAbility> _knownAbilities = new List<BaseAbility>();
        public BaseAbility CurrentAbility { get => _currentAbility; set => _currentAbility = value; }
        public AbilityComponent(Agent agent) : base(agent)
        {
            var abilities = agent.GetAbilitiesFromXML();
            if(abilities.Count > 0)
            {
                foreach (var ability in abilities)
                {
                    try
                    {
                        object instance = Activator.CreateInstance(Type.GetType(ability));
                        if (instance is BaseAbility)
                        {
                            this._knownAbilities.Add(instance as BaseAbility);
                        }
                    }
                    catch (Exception)
                    {
                        TOWCommon.Log("Failed instantiating ability class: " + ability, LogLevel.Error);
                    }
                }
                if (_knownAbilities.Count > 0) CurrentAbility = _knownAbilities[0];
            }
        }

        public void SelectAbility(int index)
        {
            if(index>=0 && index < this._knownAbilities.Count)
            {
                this.CurrentAbility = _knownAbilities[index];
            }
        }

        public void SelectNextAbility()
        {
            if(this._knownAbilities.Count > 1)
            {
                int index = this._knownAbilities.FindIndex(x => x.Name == CurrentAbility.Name);
                index += 1;
                if(index > this._knownAbilities.Count - 1)
                {
                    index = 0;
                }
                this.SelectAbility(index);
            }
        }
    }
}
