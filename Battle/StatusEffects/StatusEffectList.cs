using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TOW_Core.Battle.StatusEffects
{
    [XmlRoot("StatusEffects")]
    public class StatusEffectList
    {
        public StatusEffectList()
        {

        }

        [XmlElement("StatusEffect")]
        public List<StatusEffect> StatusEffects { get; set; }
    }
}
