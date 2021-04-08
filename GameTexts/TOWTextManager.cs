﻿using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TOW_Core.Texts
{
    public static class TOWTextManager
    {
        private static Dictionary<string, TextObject> _overrides = new Dictionary<string, TextObject>();
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Loads TOW specific strings from XML.
        /// </summary>
        internal static void LoadAdditionalTexts()
        {
            try
            {
                var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/tow_module_strings.xml");
                Game.Current.GameTextManager.LoadGameTexts(path);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw e; //TODO handle this more gracefully.
            }
        }

        /// <summary>
        /// Loads TOW specific vanilla strings' override texts.
        /// </summary>
        internal static void LoadTextOverrides()
        {
            try
            {
                var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/tow_override_strings.xml");
                if (File.Exists(path))
                {
                    var ser = new XmlSerializer(typeof(List<TOWTextOverride>));
                    var list = ser.Deserialize(File.OpenRead(path)) as List<TOWTextOverride>;
                    var dictionary = new Dictionary<string, TextObject>();
                    foreach(var item in list)
                    {
                        dictionary.Add(item.StringID, new TextObject(item.TextOverride));
                    }
                    TOWTextManager._overrides = dictionary;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw e; //TODO handle this more gracefully.
            }
        }

        /// <summary>
        /// Utility function to write override XML sample to generate the correct schema.
        /// </summary>
        internal static void WriteSampleOverrideXml()
        {
            var list = new List<TOWTextOverride>();
            list.Add(new TOWTextOverride());
            var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/tow_override_strings.xml");
            var ser = new XmlSerializer(typeof(List<TOWTextOverride>));
            ser.Serialize(File.OpenWrite(path) ,list);
        }

        /// <summary>
        /// Finds TOW specific override for the given stringId and variationID.
        /// Returns the first occurance only if multiple is present.
        /// <param name="Id"></param>
        /// <param name="text"></param>
        /// <param name="variationId"></param>
        /// <returns></returns>
        /// </summary>
        internal static bool TryGetOverrideFor(string Id, out TextObject text, string variationId = null)
        {
            var localid = Id;
            if(variationId != null)
            {
                localid += "." + variationId;
            }
            try
            {
                var match = TOWTextManager._overrides[localid];
                if (match != null && match.Length > 0)
                {
                    text = match;
                    return true;
                }
            }
            catch (KeyNotFoundException)
            {
                text = new TextObject();
                return false;
            }
            catch (Exception)
            {
                //keynotfoundexception is expected, anything else is not
                text = new TextObject();
                return false;
            }
            text = new TextObject();
            return false;
        }
    }
}
