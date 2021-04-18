using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Abilities
{
    public class AbilityComponent : AgentComponent
    {
        private BaseAbility _currentAbility;
        public BaseAbility CurrentAbility { get => _currentAbility; set => _currentAbility = value; }
        public AbilityComponent(Agent agent) : base(agent)
        {
            this._currentAbility = new FireBallAbility();
        }
    }
}
