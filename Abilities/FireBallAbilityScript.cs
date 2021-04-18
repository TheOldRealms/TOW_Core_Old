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
    public class FireBallAbilityScript : ScriptComponentBehaviour
    {
        private Agent _agent;
        private float radius = 5f;
        private int minDamage = 30;
        private int maxDamage = 80;
        private Random random;
        private bool firstCollision;
        private float speed = 50f;

        protected override TickRequirement GetTickRequirement()
        {
            return TickRequirement.Tick;
        }
        //Not sure if this is needed.
        protected override bool MovesEntity() => true;

        public void SetAgent(Agent agent)
        {
            this._agent = agent;
        }

        protected override void OnInit()
        {
            base.OnInit();
            this.SetScriptComponentToTick(this.GetTickRequirement());
            this.random = new Random();
        }

        protected override void OnTick(float dt)
        {
            base.OnTick(dt);
            var frame = base.GameEntity.GetGlobalFrame();
            var newframe = frame.Advance(speed * dt);
            base.GameEntity.SetGlobalFrame(newframe);
            base.GameEntity.GetBodyShape().ManualInvalidate();
        }

        protected override void OnPhysicsCollision(ref PhysicsContact contact)
        {
            base.OnPhysicsCollision(ref contact);
            if (!firstCollision)
            {
                base.GameEntity.FadeOut(0.1f, true);
                var collisionpoint = contact.ContactPair0.Contact0.Position;
                var collisionnormal = contact.ContactPair0.Contact0.Normal;
                var list = Mission.Current.GetNearbyEnemyAgents(collisionpoint.AsVec2, radius, _agent.Team);
                foreach (var agent in list)
                {
                    agent.ApplyDamage(random.Next(minDamage, maxDamage));
                }
                var explosion = GameEntity.CreateEmpty(Scene);
                MatrixFrame frame = MatrixFrame.Identity;
                var psys = ParticleSystem.CreateParticleSystemAttachedToEntity("psys_burning_projectile_default_coll", explosion, ref frame);
                explosion.SetGlobalFrame(new MatrixFrame(Mat3.CreateMat3WithForward(in collisionnormal), collisionpoint));
                explosion.FadeOut(3, true);
                firstCollision = true;
            }   
        }
    }
}
