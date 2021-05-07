using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using System.Xml.Serialization;
using TaleWorlds.Library;
using System.IO;

namespace TOW_Core.CharacterCreation
{
    class TOWCharacterCreationContent : CharacterCreationContentBase
    {
        private List<CharacterCreationOption> _options;
        private int _maxStageNumber = 3;

        public TOWCharacterCreationContent()
        {
            try
            {
                var path = Path.Combine(BasePath.Name, "Modules/TOW_Core/ModuleData/tow_cc_options.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<CharacterCreationOption>));
                _options = ser.Deserialize(File.OpenRead(path)) as List<CharacterCreationOption>;
            }
            catch (Exception)
            {
                TOW_Core.Utilities.TOWCommon.Log("Failed to open tow_cc_options.xml for character creation.", NLog.LogLevel.Error);
                throw;
            }
        }

        public override TextObject ReviewPageDescription
        {
            get
            {
                return new TextObject("{=!}You prepare to enter The Old World! Here is your character. Click finish if you are ready, or go back to make changes.", null);
            }
        }

        protected override void OnInitialized(TaleWorlds.CampaignSystem.CharacterCreationContent.CharacterCreation characterCreation)
        {
            AddStages(characterCreation);
        }

        private void AddStages(TaleWorlds.CampaignSystem.CharacterCreationContent.CharacterCreation characterCreation)
        {
            //stages
            CharacterCreationMenu stage1Menu = new CharacterCreationMenu(new TextObject("{=!}Stage 1 @lore: please rename me", null), new TextObject("{=!}Placeholder...", null), new CharacterCreationOnInit(OnMenuInit), CharacterCreationMenu.MenuTypes.MultipleChoice);
            CharacterCreationMenu stage2Menu = new CharacterCreationMenu(new TextObject("{=!}Stage 2 @lore: please rename me", null), new TextObject("{=!}Placeholder...", null), new CharacterCreationOnInit(OnMenuInit), CharacterCreationMenu.MenuTypes.MultipleChoice);
            CharacterCreationMenu stage3Menu = new CharacterCreationMenu(new TextObject("{=!}Stage 3 @lore: please rename me", null), new TextObject("{=!}Placeholder...", null), new CharacterCreationOnInit(OnMenuInit), CharacterCreationMenu.MenuTypes.MultipleChoice);

            for(int i = 1; i <= _maxStageNumber; i++)
            {
                List<string> cultures = new List<string>();
                _options.ForEach(x =>
                {
                    if (x.StageNumber == i && !cultures.Contains(x.Culture))
                    {
                        cultures.Add(x.Culture);
                    }
                });
                foreach(var culture in cultures)
                {
                    CharacterCreationCategory category = new CharacterCreationCategory();
                    switch (i)
                    {
                        case 1:
                            category = stage1Menu.AddMenuCategory(delegate ()
                            {
                                return GetSelectedCulture().StringId == culture;
                            });
                            break;
                        case 2:
                            category = stage2Menu.AddMenuCategory(delegate ()
                            {
                                return GetSelectedCulture().StringId == culture;
                            });
                            break;
                        case 3:
                            category = stage3Menu.AddMenuCategory(delegate ()
                            {
                                return GetSelectedCulture().StringId == culture;
                            });
                            break;
                        default:
                            break;
                    }
                    
                    var relevantOptions = _options.FindAll(x => x.StageNumber == i && x.Culture == culture);
                    foreach(var option in relevantOptions)
                    {
                        var effectedSkills = new List<SkillObject>();
                        foreach(var skillId in option.SkillsToIncrease)
                        {
                            effectedSkills.Add(SkillObject.FindFirst(x => x.StringId == skillId));
                        }
                        category.AddCategoryOption(new TextObject("{=!}"+ option.OptionText), effectedSkills, option.AttributeToIncrease, FocusToAdd, SkillLevelToAdd, AttributeLevelToAdd, null, delegate(TaleWorlds.CampaignSystem.CharacterCreationContent.CharacterCreation charInfo) 
                        {
                            OnOptionSelected(charInfo, option.Id);
                        }, 
                        null, new TextObject("{=!}" + option.OptionFlavourText));
                    }
                }
            }

            characterCreation.AddNewMenu(stage1Menu);
            characterCreation.AddNewMenu(stage2Menu);
            characterCreation.AddNewMenu(stage3Menu);
        }

        private void OnOptionSelected(TaleWorlds.CampaignSystem.CharacterCreationContent.CharacterCreation charInfo, string optionId)
        {
            var selectedOption = _options.Find(x => x.Id == optionId);
            List<Equipment> list = new List<Equipment>();
            Equipment equipment = null;
            try
            {
                equipment = Game.Current.ObjectManager.GetObject<CharacterObject>(selectedOption.CharacterIdToCopyEquipmentFrom).Equipment;
            }
            catch (NullReferenceException)
            {
                TOW_Core.Utilities.TOWCommon.Log("Attempted to read characterobject " + selectedOption.CharacterIdToCopyEquipmentFrom + " in Character Creation, but no such entry exists in XML. Falling back to default.", NLog.LogLevel.Error);
                throw;
            }
            if (equipment != null)
            {
                if (equipment.IsValid && !equipment.IsEmpty())
                {
                    list.Add(equipment);
                    charInfo.ChangeCharactersEquipment(list);
                    PlayerStartEquipment = equipment;
                    CharacterObject.PlayerCharacter.Equipment.FillFrom(PlayerStartEquipment);
                }
            }
        }

        private void OnMenuInit(TaleWorlds.CampaignSystem.CharacterCreationContent.CharacterCreation charInfo)
        {
            charInfo.IsPlayerAlone = true;
            charInfo.HasSecondaryCharacter = false;
            charInfo.ClearFaceGenMounts();
        }
    }
}
