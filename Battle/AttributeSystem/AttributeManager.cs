using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace TOW_Core.Battle.AttributeSystem
{
    public class AttributeManager
    {
        private readonly string ModuleName = "TOW_Core";
        private readonly string AttributeFileName = "tow_characterattributes.xml";

        private Dictionary<string, List<string>> TroopNameToAttributeList = new Dictionary<string, List<string>>();
        private static AttributeManager _instance;
        private bool _isLoaded = false;
        public static AttributeManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AttributeManager();
                return _instance;
            }
        }

        public void LoadAttributes()
        {
            if(!_isLoaded)
            {
                var files = Directory.GetFiles(ModuleHelper.GetModuleFullPath(ModuleName), AttributeFileName, SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    XmlDocument attributeXml = new XmlDocument();
                    attributeXml.Load(file);
                    XmlNodeList characters = attributeXml.GetElementsByTagName("Character");
                    foreach (XmlNode character in characters)
                    {
                        List<string> attributes = new List<string>();
                        foreach (XmlNode attributeNode in character.ChildNodes)
                        {
                            if (attributeNode.NodeType == XmlNodeType.Comment)
                            {
                                continue;
                            }
                            attributes.Add(attributeNode.Attributes["id"].Value);
                        }
                        TroopNameToAttributeList.Add(character.Attributes["name"].Value, attributes);
                    }
                }

                _isLoaded = true;
            }
        }

        public List<string> GetAttributes(Agent agent)
        {
            if (agent != null && agent.Character != null)
            {
                string characterName = agent.Character.GetName().ToString();

                List<string> attributeList;
                if (TroopNameToAttributeList.TryGetValue(characterName, out attributeList))
                {
                    return attributeList;
                }
            }
            return new List<string>();
        }
    }
}
