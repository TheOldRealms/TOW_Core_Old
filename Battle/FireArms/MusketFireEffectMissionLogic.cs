using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TOW_Core.Utilities;

namespace TOW_Core.Battle.FireArms
{
    public class MusketFireEffectMissionLogic : MissionLogic
    {
        public override void OnAgentShootMissile(Agent shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, int forcedMissileIndex)
        {
            base.OnAgentShootMissile(shooterAgent, weaponIndex, position, velocity, orientation, hasRigidBody, forcedMissileIndex);
            if(shooterAgent.WieldedWeapon.Item.StringId == "tow_musket_001")
            {
                var direction = shooterAgent.LookDirection;
                var frame = new MatrixFrame(Mat3.CreateMat3WithForward(in direction), position);
                frame = frame.Advance(1.1f);
                frame.Rotate(TOWMath.GetDegreeInRadians(90f), Vec3.Up);
                Mission.AddParticleSystemBurstByName("handgun_shoot", frame, false);
            }
        }
    }
}
