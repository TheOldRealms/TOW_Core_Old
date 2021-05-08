using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using TOW_Core.Utilities;

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class MBObjectManagerPatch
    {
        private static readonly Dictionary<string, string> _typesToForce = new Dictionary<string, string>() 
        {
            {"Settlements", "tow_settlements.xml"}
        };

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MBObjectManager), "LoadXML")]
        public static bool Prefix(string id, MBObjectManager __instance)
        {
            return false;
            if (_typesToForce.ContainsKey(id))
            {
                try
                {
                    var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/" + _typesToForce[id]);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    __instance.LoadXml(doc, null);
                    return true;
                }
                catch (Exception)
                {
                    TOWCommon.Log("Error in MBObjectManagerPatch, tried to force load TOW specific xml but failed.", NLog.LogLevel.Error);
                    return false;
                }
            }
            else return false;
        }
    }
}
