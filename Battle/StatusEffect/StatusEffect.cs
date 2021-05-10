using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    public class  StatusEffect
    {
        //TODO include some dummy Status effect data types, that can be checked
        public bool active{ get; set; }
        public int id{ get; set; }
        public float duration { get; set; }
        public float _currentduration;

        public Agent affector = null;

        public EffectType _EffectType;


        public EffectContainer EffectContainer;
        public enum EffectType
        {
            Armor, 
            Health, 
            Damage
            EOT
        }


        public void Activate()
        {
            
        }

        //needs refinement since this can't be defined. and need to be assigned on runtime
    }
    
    
    public class EffectContainer
    {
        public float _healthOverTime;  //all hots(heal over time) and dots(damge over time)  negative numbers resemble a dot.
        public List<DamageTypes> receivedDamageTypes;
        
        //armor related
        public float WardSaveFactor;  // between 0 and 1 , 1 means full damage, 0 means 0 damage
        public float Armorvalue;      //between 0 and infite added at the end of damage calculation of beeing hit
        public float ArmorPercentage; //percental 
        private List<DamageTypes> protectionTypes;// all Damage types the agent suffers of.
        //damage related
        public float _damageValue;      //between 0 and infinite added at the end of a damage calculation of a hit. base Damage
        public float _damagePercentage; //damage Percentage after all effects are added
        public List<DamageTypes> _attackDamageTypes;   //NOT FUNCTIONAL Implies all kind of damage types for an output attack
    }
}
}