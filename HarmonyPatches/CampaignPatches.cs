﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;
using TOW_Core.Utilities;

//Need a way to somehow skip loading of vanilla xmls in the following categories:
//Settlements, Factions, Kingdoms, NPCCharacters

namespace TOW_Core.HarmonyPatches
{
    [HarmonyPatch]
    public static class CampaignPatches
    {
        private static readonly Dictionary<string, string> _typesToForce = new Dictionary<string, string>() 
        {
            {"Settlements", "tow_settlements.xml"},
            {"Heroes", "tow_heroes.xml"},
            {"Kingdoms", "tow_kingdoms.xml"},
            {"Factions", "tow_clans.xml"},
        };

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MBObjectManager), "LoadXML")]
        public static bool Prefix(string id, MBObjectManager __instance)
        {
            if (_typesToForce.ContainsKey(id))
            {
                try
                {
                    var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/" + _typesToForce[id]);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    __instance.LoadXml(doc, null);
                    return false;
                }
                catch (Exception)
                {
                    TOWCommon.Log("Error in MBObjectManagerPatch, tried to force load TOW specific xml but failed.", NLog.LogLevel.Error);
                    return true;
                }
            }
            else return true;
        }

        //Only spawn wanderers for empire and khuzait, the rest crashes because there are no settlements for the other cultures.
        [HarmonyPrefix]
        [HarmonyPatch(typeof(UrbanCharactersCampaignBehavior), "CreateCompanion")]
        public static bool Prefix2(CharacterObject companionTemplate)
        {
            if (companionTemplate == null || !companionTemplate.Culture.IsMainCulture)
            {
                return false;
            }
            else return true;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Kingdom), "InitialHomeLand", MethodType.Getter)]
        public static void Postfix(ref Settlement __result, Kingdom __instance)
        {
            if(__result == null)
            {
                __result = Settlement.All.FirstOrDefault((Settlement x) => x.IsTown && x.MapFaction == __instance.MapFaction);
                if (__result == null)
                {
                    __result = Settlement.All.FirstOrDefault((Settlement x) => x.IsTown);
                }
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BackstoryCampaignBehavior), "RegisterEvents")]
        public static bool Prefix3()
        {
            return false;
        }
    }
}
