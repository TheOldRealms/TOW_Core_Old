using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Battle.Extensions;

namespace TOW_Core.Abilities
{
    class FireBallAbility : BaseAbility
    {
        public override void Use(Agent agent)
        {
            base.Use(agent);
            if(agent.IsActive() && agent.Health > 0 && agent.GetMorale() > 1 && agent.IsAbilityUser())
            {
                var scene = Mission.Current.Scene;
                var offset = 3f;
                var speed = 50f;
                var mass = 1f;

                var frame = agent.LookFrame.Elevate(agent.GetEyeGlobalHeight());
                frame = frame.Advance(offset);
                var entity = GameEntity.Instantiate(scene, "fireball_prefab", true);
                //entity.AddMultiMesh(MetaMesh.GetCopy("projectile_pot"));
                //entity.AddPhysics(mass, Vec3.Zero, PhysicsShape.GetFromResource("bo_projectile_rock"), Vec3.Zero, Vec3.Zero, PhysicsMaterial.GetFromName("burning_jar"), true, -1);
                entity.SetGlobalFrame(frame);
                entity.AddSphereAsBody(Vec3.Zero, 0.2f, BodyFlags.Moveable);
                entity.AddPhysics(mass, entity.CenterOfMass, entity.GetBodyShape(), Vec3.Zero, Vec3.Zero, PhysicsMaterial.GetFromName("burning_jar"), false, -1);
                entity.SetPhysicsState(true, true);
                //entity.EnableDynamicBody();
                //entity.ApplyImpulseToDynamicBody(entity.CenterOfMass, frame.rotation.f.NormalizedCopy() * speed);
                entity.CreateAndAddScriptComponent("FireBallAbilityScript");
                FireBallAbilityScript script = entity.GetFirstScriptOfType<FireBallAbilityScript>();
                script.SetAgent(agent);
                entity.CallScriptCallbacks();
            }
        }
    }
}
