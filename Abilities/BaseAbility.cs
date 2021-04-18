using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Abilities
{
    public abstract class BaseAbility
    {
        virtual public void Use(Agent agent) { }
    }
}
