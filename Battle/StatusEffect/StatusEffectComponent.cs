using System.Collections.Generic;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    //resides on Each agent
    public class StatusEffectComponent: AgentComponent
    {
        private List<Buff> _buffEffects;
        private List<Debuff> _debuffEffects;


        private float _damageValue;      //between 0 and infinite added at the end of a damage calculation of a hit
        private float _armorvalue;      //between 0 and infite added at the end of damage calculation of beeing hit
        private float _speedfactor;      //between 0 and a reasonable number(maybe 2) percentage of movement speed
        private float _staggering
        

        public StatusEffectComponent(Agent agent) : base(agent)
        {
        }
        
        public void InitializeStatusEffect(IStatusEffect effect){} //called at the beginning of mission fills all possible buffs and debuffs
        
        
        
        
        
    }
}