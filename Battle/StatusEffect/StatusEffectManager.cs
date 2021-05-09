using System;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.StatusEffect
{
    public class StatusEffectManager: MissionBehaviour
    {
        //assigns all valid Statuseffect Option at the beginning of the Mission to Status effect Components residing on every agent

        public override MissionBehaviourType BehaviourType { get; }
        
       public EventHandler<OnTickArgs> NotifyStatusEffectTickObservers;
        public virtual void OnMissionTick(float dt)
        {
            OnTickArgs arguments = new OnTickArgs() {deltatime = dt};
            NotifyStatusEffectTickObservers.Invoke(this,arguments);
        }
        
    }



    public class OnTickArgs : EventArgs
    {
        public float deltatime;
    }
}