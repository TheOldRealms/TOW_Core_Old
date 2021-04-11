using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.AttributeSystem.CustomAgentComponents;

namespace TOW_Core.Battle.AttributeSystem.CustomMissionLogic
{
    class AttributeSystemMissionLogic : MissionLogic
    {
        public AttributeSystemMissionLogic()
        {
        }

        public override void OnAgentCreated(Agent agent)
        {
            base.OnAgentCreated(agent);

            List<string> attributeList = AttributeManager.Instance.GetAttributes(agent);
            attributeList.ForEach(attribute => ApplyAgentComponentsForAttribute(attribute, agent));
        }

        private void ApplyAgentComponentsForAttribute(string attribute, Agent agent)
        {
            switch (attribute)
            {
                case "Expendable":
                    //Expendable units are handled in the mission's morale interaction logic
                    break;
                case "Undead":
                    agent.AddComponent(new UndeadMoraleAgentComponent(agent));
                    break;
            }
        }
    }
}
