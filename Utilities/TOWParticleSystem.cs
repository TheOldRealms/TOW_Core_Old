using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Utilities
{
    /// <summary>
    /// Provides particle-specific functions for use cases that are expected to be reused
    /// throughout the code base.
    /// </summary>
    public class TOWParticleSystem
    {
        /// <summary>
        /// Attach a particle to an agent. Returns the list of ParticleSystems added so the caller
        /// can modify and manage the added particles.
        /// </summary>
        /// <param name="agent">The agent receiving the particle system.</param>
        /// <param name="particleId">The Id of the particle system.</param>
        /// <returns>A List of ParticleSystems attached to the agent</returns>
        public static List<ParticleSystem> ApplyParticleToAgent(Agent agent, string particleId)
        {
            List<ParticleSystem> particleList = new List<ParticleSystem>();
            int[] boneIndexes = { 0, 1, 2, 3, 5, 6, 7, 9, 12, 13, 15, 17, 22, 24 };
            Skeleton skeleton = agent.AgentVisuals.GetSkeleton();
            for (byte i = 0; i < boneIndexes.Length; i++)
            {
                MatrixFrame localFrame = new MatrixFrame(Mat3.Identity, new Vec3(0, 0, 0));
                ParticleSystem particle = ParticleSystem.CreateParticleSystemAttachedToBone(particleId, skeleton, (sbyte)boneIndexes[i], ref localFrame);
                particleList.Add(particle);
            }
            return particleList;
        }
    }
}
