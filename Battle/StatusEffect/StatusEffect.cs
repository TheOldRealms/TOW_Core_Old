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
        //needs refinement since this can't be defined. and need to be assigned on runtime
    }
}