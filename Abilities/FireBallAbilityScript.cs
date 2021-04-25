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
        private float _radius = 5f;
        private int _minDamage = 60;
        private int _maxDamage = 100;
        private Random _random;
        private bool _firstCollision;
        private float _speed = 40f;
        private FireBallAbility _ability;
        private float _abilitylife = -1f;
        private bool _isFading;
        private int _movingSoundindex;
        private int _explosionSoundindex;
        private SoundEvent _movingSound;

        protected override void OnRemoved(int removeReason)
        {
            base.OnRemoved(removeReason);
            //clean up
            this._movingSound.Release();
            this._random = null;
            this._agent = null;
            this._ability = null;
            this._movingSound = null;
        }

        protected override TickRequirement GetTickRequirement()
        {
            return TickRequirement.Tick;
        }
        protected override bool MovesEntity() => true;
        public void SetAgent(Agent agent) => this._agent = agent;
        public void SetAbility(FireBallAbility fireBallAbility) => this._ability = fireBallAbility;

        protected override void OnInit()
        {
            base.OnInit();
            this.SetScriptComponentToTick(this.GetTickRequirement());
            _random = new Random();
            this._movingSoundindex = SoundEvent.GetEventIdFromString("fireball");
            this._explosionSoundindex = SoundEvent.GetEventIdFromString("fireball_explosion");

        }

        protected override void OnTick(float dt)
        {
            base.OnTick(dt);

            var frame = base.GameEntity.GetGlobalFrame();
            var newframe = frame.Advance(_speed * dt);
            base.GameEntity.SetGlobalFrame(newframe);
            base.GameEntity.GetBodyShape().ManualInvalidate();
            if (_abilitylife < 0)
            {
                _abilitylife = 0;
            }
            else
            {
                _abilitylife += dt;
            }
            if (_ability != null)
            {
                if (_abilitylife > _ability.MaxDuration && !_isFading)
                {
                    base.GameEntity.FadeOut(0.1f, true);
                    _isFading = true;
                }
            }
            if(this._movingSound == null)
            {
                this._movingSound = SoundEvent.CreateEvent(this._movingSoundindex, Scene);
                this._movingSound.SetPosition(newframe.origin);
                this._movingSound.Play();
            }
            this._movingSound.SetPosition(newframe.origin);
        }

        protected override void OnPhysicsCollision(ref PhysicsContact contact)
        {
            base.OnPhysicsCollision(ref contact);
            if (!_firstCollision)
            {
                base.GameEntity.FadeOut(0.1f, true);
                _isFading = true;
                var collisionpoint = contact.ContactPair0.Contact0.Position;
                var collisionnormal = contact.ContactPair0.Contact0.Normal;
                var list = Mission.Current.GetNearbyEnemyAgents(collisionpoint.AsVec2, _radius, _agent.Team);
                foreach (var agent in list)
                {
                    agent.ApplyDamage(_random.Next(_minDamage, _maxDamage), _agent);
                }
                var explosion = GameEntity.CreateEmpty(Scene);
                MatrixFrame frame = MatrixFrame.Identity;
                var psys = ParticleSystem.CreateParticleSystemAttachedToEntity("psys_burning_projectile_default_coll", explosion, ref frame);
                var globalFrame = new MatrixFrame(Mat3.CreateMat3WithForward(in collisionnormal), collisionpoint);
                explosion.SetGlobalFrame(globalFrame);
                explosion.FadeOut(3, true);
                Mission.Current.MakeSound(this._explosionSoundindex, globalFrame.origin, false, true, -1, -1);
                _firstCollision = true;
            }
        }

    }
}
