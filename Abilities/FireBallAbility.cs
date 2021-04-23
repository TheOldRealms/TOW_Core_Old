﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using System.Xml.Serialization;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;

namespace TOW_Core.Abilities
{
    public class FireBallAbility : BaseAbility
    {
        public FireBallAbility() : base()
        {
            this.CoolDown = 20;
            this.MaxDuration = 3f;
            this.Name = "Fireball";
            this.SpriteName = "fireball_icon";
        }

        protected override void OnUse(Agent agent)
        {
            if(agent.IsActive() && agent.Health > 0 && agent.GetMorale() > 1 && agent.IsAbilityUser())
            {
                var scene = Mission.Current.Scene;
                var offset = 1f;
                var mass = 1f;
                var lightradius = 10f;

                var frame = agent.LookFrame.Elevate(agent.GetEyeGlobalHeight());
                frame = frame.Advance(offset);
                var entity = GameEntity.Instantiate(scene, "fireball_prefab", true);
                entity.SetGlobalFrame(frame);
                
                var light = Light.CreatePointLight(lightradius);
                light.Intensity = 50;
                light.LightColor = new Vec3(255, 170, 0);
                light.Frame = MatrixFrame.Identity;
                light.SetVisibility(true);
                light.SetLightFlicker(3f, .7f);
                
                entity.AddLight(light);
                
                
                entity.AddSphereAsBody(Vec3.Zero, 0.2f, BodyFlags.Moveable);
                entity.AddPhysics(mass, entity.CenterOfMass, entity.GetBodyShape(), Vec3.Zero, Vec3.Zero, PhysicsMaterial.GetFromName("missile"), false, -1);
                entity.SetPhysicsState(true, false);
                entity.CreateAndAddScriptComponent("FireBallAbilityScript");
                
                FireBallAbilityScript script = entity.GetFirstScriptOfType<FireBallAbilityScript>();
                script.SetAgent(agent);
                script.SetAbility(this);
                
                entity.CallScriptCallbacks();
            }
        }
    }
}