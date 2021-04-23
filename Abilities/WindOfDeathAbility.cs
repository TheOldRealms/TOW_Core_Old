using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;

namespace TOW_Core.Abilities
{
    public class WindOfDeathAbility : BaseAbility
    {
        public WindOfDeathAbility() : base()
        {
            this.CoolDown = 40;
            this.MaxDuration = 5f;
            this.Name = "Wind of Death";
            this.SpriteName = "windofdeath_icon";
        }

        protected override void OnUse(Agent agent)
        {
            if (agent.IsActive() && agent.Health > 0 && agent.GetMorale() > 1 && agent.IsAbilityUser())
            {
                var scene = Mission.Current.Scene;
                var offset = 10f;
                var lightradius = 10f;

                var frame = agent.LookFrame;
                frame = frame.Advance(offset);
                var height = scene.GetTerrainHeight(frame.origin.AsVec2);
                frame.origin.z = height;
                var entity = GameEntity.Instantiate(scene, "wind_of_death_vfx", true);
                entity.SetGlobalFrame(frame);

                var light = Light.CreatePointLight(lightradius);
                light.Intensity = 50;
                light.LightColor = new Vec3(255, 170, 0);
                light.Frame = MatrixFrame.Identity;
                light.SetVisibility(true);
                light.SetLightFlicker(3f, .7f);

                entity.AddLight(light);

                entity.CreateAndAddScriptComponent("WindOfDeathAbilityScript");
                WindOfDeathAbilityScript script = entity.GetFirstScriptOfType<WindOfDeathAbilityScript>();
                script.SetAgent(agent);
                script.SetAbility(this);

                entity.CallScriptCallbacks();
            }
        }
    }
}
