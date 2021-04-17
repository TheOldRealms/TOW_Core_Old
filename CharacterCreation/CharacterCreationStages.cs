using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using StoryMode.CharacterCreationContent;
using System.Collections.Generic;
using TaleWorlds.Localization;

namespace TOW_Core
{
    public class CharacterCreationStages
    {
        private static StoryModeCharacterCreationContent cc;

        public static void AddParentsMenu(CharacterCreation characterCreation, StoryModeCharacterCreationContent storyModeCharacterCreation)
        {
            cc = storyModeCharacterCreation;

            CharacterCreationMenu ParentsMenu = new CharacterCreationMenu(new TextObject("{=b4lDDcli}Family"), new TextObject("Your parent was a"), new CharacterCreationOnInit(ParentsOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory ParentsMenuCreationCategory = ParentsMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.Steward);
            Skills0.Add(DefaultSkills.Leadership);
            TextObject text0 = new TextObject("Captain of the Empire");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(ParentCaptainOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("Your father served his Elector diligently and lived long enough to become a veteran, a rare sight within the Empire. Proudly wearing the scars earned from a life of fighting beastmen, he commanded respect and was known for his martial skill");
            ParentsMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Vigor, 1, 15, 1, optionCondition0, onSelect0, onApply0, descriptionText0);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.Trade);
            Skills1.Add(DefaultSkills.Charm);
            TextObject text1 = new TextObject("Merchant");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(ParentMerchantOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("Hailing from a long line of merchants, your family made its wealth peddling the various crafts along the River Stir. Ranald did not look upon your parents with kindness however and they could only just make ends meet.");
            ParentsMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition1, onSelect1, onApply1, descriptionText1);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.Engineering);
            Skills2.Add(DefaultSkills.OneHanded);
            TextObject text2 = new TextObject("Imperial Engineer");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(ParentEngineerOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("Your father was a tinkerer and spoke of little else but his schemes and ideas, the Colleges of Nuln had given him a stable life and your upbringing involved playing with things that perhaps, no child should be touching.");
            ParentsMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Intelligence, 1, 15, 1, optionCondition2, onSelect2, onApply2, descriptionText2);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Crafting);
            Skills3.Add(DefaultSkills.TwoHanded);
            TextObject text3 = new TextObject("Blacksmith");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(ParentBlacksmithOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("The Empire is never short of enemies and as such, could never be short of weapons. Your father crafted blades and armour for State Troops and militia alike, proudly claiming that his blades would \"cut down any beast!\"");
            ParentsMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition3, onSelect3, onApply3, descriptionText3);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Scouting);
            Skills4.Add(DefaultSkills.Bow);
            TextObject text4 = new TextObject("Hunter");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(ParentHunterOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("A simple man, your family was sustained by your fathers trips deep into the forest and his skill with a bow. It was a meagre living but you had a roof over your head and at times food in your belly.");
            ParentsMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Control, 1, 15, 1, optionCondition4, onSelect4, onApply4, descriptionText4);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Roguery);
            Skills5.Add(DefaultSkills.Throwing);
            TextObject text5 = new TextObject("Thief");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(ParentThiefOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("There is no shortage of thieves and brigands in the Empire, your father amongst them. While he would claim that none were ever hurt as he pilfered the houses of wealthy merchants, only he knew the truth to that claim");
            ParentsMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Cunning, 1, 15, 1, optionCondition5, onSelect5, onApply5, descriptionText5);

            List<SkillObject> Skills6 = new List<SkillObject>();
            Skills6.Add(DefaultSkills.Riding);
            Skills6.Add(DefaultSkills.Polearm);
            TextObject text6 = new TextObject("Vampiric Noble");
            CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(ParentVampiricNobleOnConsequence);
            CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText6 = new TextObject("-");
            ParentsMenuCreationCategory.AddCategoryOption(text6, Skills6, CharacterAttributesEnum.Social, 1, 20, 1, optionCondition6, onSelect6, onApply6, descriptionText6);

            List<SkillObject> Skills7 = new List<SkillObject>();
            Skills7.Add(DefaultSkills.OneHanded);
            //necormancy
            TextObject text7 = new TextObject("Weak Necromancer");
            CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(ParentNecromancerOnConsequence);
            CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText7 = new TextObject("Little could be said for your fathers sanity, his days were dedicated to dissecting scrolls and performing dark rituals. Obsessed with becoming powerful yet unable to master even the basics, his failures drove him to madness and he wandered deep into the swamps. Vanishing.");
            ParentsMenuCreationCategory.AddCategoryOption(text7, Skills7, CharacterAttributesEnum.Cunning, 1, 15, 1, optionCondition7, onSelect7, onApply7, descriptionText7);

            List<SkillObject> Skills8 = new List<SkillObject>();
            Skills8.Add(DefaultSkills.Trade);
            Skills8.Add(DefaultSkills.Charm);
            TextObject text8 = new TextObject("Stirland Merchant");
            CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(ParentStirlandMerchantOnConsequence);
            CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText8 = new TextObject("Very few risk travel into Sylvania, let alone with trade goods in tow. Your family were either incredibly brave, or incredibly desperate, to travel the dark roads plagued with bandits, the undead and worse..");
            ParentsMenuCreationCategory.AddCategoryOption(text8, Skills8, CharacterAttributesEnum.Intelligence, 1, 15, 1, optionCondition8, onSelect8, onApply8, descriptionText8);

            List<SkillObject> Skills9 = new List<SkillObject>();
            Skills9.Add(DefaultSkills.Charm);
            Skills9.Add(DefaultSkills.Steward);
            TextObject text9 = new TextObject("Priest of Morr");
            CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(ParentPriestofMorrOnConsequence);
            CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText9 = new TextObject("The dead do not rest easy in Sylvania and the work of Morr is never done, your father was a quiet man whose life was a dedication to death. Maintaining a garden of Morr and performing the necessary rights to ensure the dead would rest, sometimes having to do so more than once.");
            ParentsMenuCreationCategory.AddCategoryOption(text9, Skills9, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition9, onSelect9, onApply9, descriptionText9);

            List<SkillObject> Skills10 = new List<SkillObject>();
            Skills10.Add(DefaultSkills.Scouting);
            Skills10.Add(DefaultSkills.TwoHanded);
            TextObject text10 = new TextObject("Woodsman");
            CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(ParentWoodsmanOnConsequence);
            CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText10 = new TextObject("-");
            ParentsMenuCreationCategory.AddCategoryOption(text10, Skills10, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition10, onSelect10, onApply10, descriptionText10);

            List<SkillObject> Skills11 = new List<SkillObject>();
            Skills10.Add(DefaultSkills.Throwing);
            Skills10.Add(DefaultSkills.Trade);
            TextObject text11 = new TextObject("Fisherman");
            CharacterCreationOnCondition optionCondition11 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(ParentFishermanOnConsequence);
            CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText11 = new TextObject("-");
            ParentsMenuCreationCategory.AddCategoryOption(text11, Skills11, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition11, onSelect11, onApply11, descriptionText11);

            characterCreation.AddNewMenu(ParentsMenu);
        }

        public static void AddChildhoodMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu ChildhoodMenu = new CharacterCreationMenu(new TextObject("{=8Yiwt1z6}Early Childhood"), new TextObject("{=character_creation_content_16}As a child you were noted for..."), new CharacterCreationOnInit(ChildhoodOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory ChildhoodMenuCreationCategory = ChildhoodMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.Leadership);
            Skills0.Add(DefaultSkills.Tactics);
            TextObject text0 = new TextObject("{=kmM68Qx4}your leadership skills");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(ChildhoodLeadershipOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("{=FfNwXtii}If the wolf pup gang of your early childhood had an alpha, it was definitely you. All the other kids followed your lead as you decided what to play and where to play, and led them in games and mischief");
            ChildhoodMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Cunning, 1, 10, 1, optionCondition0, onSelect0, onApply0, descriptionText0);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.TwoHanded);
            Skills1.Add(DefaultSkills.Throwing);
            TextObject text1 = new TextObject("your brawn");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(ChildhoodBrawnOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("{=YKzuGc54}You were big, and other children looked to have you around in any scrap with children from a neighboring village. You pushed a plough and throw an axe like an adult");
            ChildhoodMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Vigor, 1, 10, 1, optionCondition1, onSelect1, onApply1, descriptionText1);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.Athletics);
            Skills2.Add(DefaultSkills.OneHanded);
            TextObject text2 = new TextObject("{=QrYjPUEf}your attention to detail");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(ChildhoodDetailOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("{=JUSHAPnu}You were quick on your feet and attentive to what was going on around you. Usually you could run away from trouble, though you could give a good account of yourself in a fight with other children if cornered");
            ChildhoodMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Control, 1, 10, 1, optionCondition2, onSelect2, onApply2, descriptionText2);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Engineering);
            Skills3.Add(DefaultSkills.Trade);
            TextObject text3 = new TextObject("{=Y3UcaX74}your aptitude for numbers");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(ChildhoodNumbersOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("{=DFidSjIf}Most children around you had only the most rudimentary education, but you lingered after class to study letters and mathematics. You were fascinated by the marketplace - weights and measures, tallies and accounts, the chatter about profits and losses");
            ChildhoodMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Intelligence, 1, 10, 1, optionCondition3, onSelect3, onApply3, descriptionText3);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Charm);
            Skills4.Add(DefaultSkills.Leadership);
            TextObject text4 = new TextObject("{=GEYzLuwb}your way with people");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(ChildhoodPeopleOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("{=w2TEQq26}You were always attentive to other people, good at guessing their motivations. You studied how individuals were swayed, and tried out what you learned from adults on your friends");
            ChildhoodMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Social, 1, 10, 1, optionCondition4, onSelect4, onApply4, descriptionText4);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Riding);
            Skills5.Add(DefaultSkills.Medicine);
            TextObject text5 = new TextObject("{=MEgLE2kj}your skill with horses");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(ChildhoodHorseOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("{=ngazFofr}You were always drawn to animals, and spent as much time as possible hanging out in the village stables. You could calm horses, and were sometimes called upon to break in new colts. You learned the basics of veterinary arts, much of which is applicable to humans as well");
            ChildhoodMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition5, onSelect5, onApply5, descriptionText5);

            characterCreation.AddNewMenu(ChildhoodMenu);
        }

        public static void AddAdolescenceMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu AdolescenceMenu = new CharacterCreationMenu(new TextObject("{=rcoueCmk}Adolescence"), new TextObject("Bursting with the energy of youth and needing purpose, you decided to"), new CharacterCreationOnInit(AdolescenceOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory AdolescenceMenuCreationCategory = AdolescenceMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.Leadership);
            Skills0.Add(DefaultSkills.Charm);
            TextObject text0 = new TextObject("Serve a Noble as an attendant");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(AdolescenceAttendantOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Social, 1, 10, 1, optionCondition0, onSelect0, onApply0, descriptionText0);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.Athletics);
            Skills1.Add(DefaultSkills.Polearm);
            TextObject text1 = new TextObject("Spar with members of the village militia");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(AdolescenceVillageMilitiaOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Vigor, 1, 10, 1, optionCondition1, onSelect1, onApply1, descriptionText1);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.TwoHanded);
            Skills2.Add(DefaultSkills.Crafting);
            TextObject text2 = new TextObject("Work for the village blacksmith");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(AdolescenceBlacksmithOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition2, onSelect2, onApply2, descriptionText2);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Crafting);
            Skills3.Add(DefaultSkills.Engineering);
            TextObject text3 = new TextObject("Study under a retired Imperial Engineer");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(AdolescenceEngineerOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Intelligence, 1, 10, 1, optionCondition3, onSelect3, onApply3, descriptionText3);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Medicine);
            Skills4.Add(DefaultSkills.Steward);
            TextObject text4 = new TextObject("Assist the local Priestess of Shallya");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(AdolescencePriestessOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Intelligence, 1, 10, 1, optionCondition4, onSelect4, onApply4, descriptionText4);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Bow);
            Skills5.Add(DefaultSkills.Scouting);
            TextObject text5 = new TextObject("Join experienced hunters on their trips");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(AdolescenceHunterOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Control, 1, 10, 1, optionCondition5, onSelect5, onApply5, descriptionText5);

            List<SkillObject> Skills6 = new List<SkillObject>();
            Skills6.Add(DefaultSkills.Tactics);
            Skills6.Add(DefaultSkills.Charm);
            TextObject text6 = new TextObject("Observe quietly within the court of the Von Carsteins");
            CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(AdolescenceCourtOnConsequence);
            CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText6 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text6, Skills6, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition6, onSelect6, onApply6, descriptionText6);

            List<SkillObject> Skills7 = new List<SkillObject>();
            Skills7.Add(DefaultSkills.Steward);
            Skills7.Add(DefaultSkills.Medicine);
            TextObject text7 = new TextObject("Help tend to the Gardens of Morr");
            CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(AdolescenceMorrOnConsequence);
            CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText7 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text7, Skills7, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition7, onSelect7, onApply7, descriptionText7);

            List<SkillObject> Skills8 = new List<SkillObject>();
            Skills8.Add(DefaultSkills.Roguery);
            Skills8.Add(DefaultSkills.OneHanded);
            TextObject text8 = new TextObject("Become a gravedigger to earn coin");
            CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(AdolescenceGravediggerOnConsequence);
            CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText8 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text8, Skills8, CharacterAttributesEnum.Cunning, 1, 10, 1, optionCondition8, onSelect8, onApply8, descriptionText8);

            List<SkillObject> Skills9 = new List<SkillObject>();
            Skills9.Add(DefaultSkills.Charm);
            Skills9.Add(DefaultSkills.Steward);
            TextObject text9 = new TextObject("Work as a stableboy for the local tavern");
            CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(AdolescenceStableboyOnConsequence);
            CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText9 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text9, Skills9, CharacterAttributesEnum.Social, 1, 10, 1, optionCondition9, onSelect9, onApply9, descriptionText9);

            List<SkillObject> Skills10 = new List<SkillObject>();
            Skills10.Add(DefaultSkills.Athletics);
            Skills10.Add(DefaultSkills.Throwing);
            TextObject text10 = new TextObject("Lend a hand to the local frogwives");
            CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(AdolescenceFrogwivesOnConsequence);
            CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText10 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text10, Skills10, CharacterAttributesEnum.Control, 1, 10, 1, optionCondition10, onSelect10, onApply10, descriptionText10);

            List<SkillObject> Skills11 = new List<SkillObject>();
            Skills11.Add(DefaultSkills.TwoHanded);
            Skills11.Add(DefaultSkills.Scouting);
            TextObject text11 = new TextObject("Work alongside the local woodsmen");
            CharacterCreationOnCondition optionCondition11 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(AdolescenceWoodsmenOnConsequence);
            CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText11 = new TextObject("-");
            AdolescenceMenuCreationCategory.AddCategoryOption(text11, Skills11, CharacterAttributesEnum.Vigor, 1, 10, 1, optionCondition11, onSelect11, onApply11, descriptionText11);

            characterCreation.AddNewMenu(AdolescenceMenu);
        }

        public static void AddYouthMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu YouthMenu = new CharacterCreationMenu(new TextObject("{=ok8lSW6M}Youth"), new TextObject("Growing up in the Old World, conflict is never far away. You decided to.."), new CharacterCreationOnInit(YouthOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory YouthMenuCreationCategory = YouthMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.Tactics);
            Skills0.Add(DefaultSkills.Leadership);
            TextObject text0 = new TextObject("Join the retinue of the local Captain of the Guard");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(YouthGuardOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Cunning, 1, 15, 1, optionCondition0, onSelect0, onApply0, descriptionText0);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.Riding);
            Skills1.Add(DefaultSkills.Polearm);
            TextObject text1 = new TextObject("Become a squire for a local noble knight");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(YouthSquireOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition1, onSelect1, onApply1, descriptionText1);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.Crossbow);
            Skills2.Add(DefaultSkills.OneHanded);
            TextObject text2 = new TextObject("Enlist with the village militiamen");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(YouthMilitiamenOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Vigor, 1, 15, 1, optionCondition2, onSelect2, onApply2, descriptionText2);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Charm);
            Skills3.Add(DefaultSkills.Trade);
            TextObject text3 = new TextObject("Travel alongside Merchant caravans");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(YouthMerchantOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition3, onSelect3, onApply3, descriptionText3);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Charm);
            Skills4.Add(DefaultSkills.Steward);
            TextObject text4 = new TextObject("Become an attendee of the local noble courts");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(YouthAttendeeOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition4, onSelect4, onApply4, descriptionText4);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Bow);
            Skills5.Add(DefaultSkills.OneHanded);
            TextObject text5 = new TextObject("Join the ranks of the local huntsmen");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(YouthHuntsmenOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Control, 1, 15, 1, optionCondition5, onSelect5, onApply5, descriptionText5);

            List<SkillObject> Skills6 = new List<SkillObject>();
            Skills6.Add(DefaultSkills.Riding);
            Skills6.Add(DefaultSkills.Tactics);
            TextObject text6 = new TextObject("Serve as a nobles squire");
            CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(YouthVCSquireOnConsequence);
            CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText6 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text6, Skills6, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition6, onSelect6, onApply6, descriptionText6);

            List<SkillObject> Skills7 = new List<SkillObject>();
            Skills7.Add(DefaultSkills.Polearm);
            TextObject text7 = new TextObject("Become a necromancer's apprentice");
            CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(YouthApprenticeOnConsequence);
            CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText7 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text7, Skills7, CharacterAttributesEnum.Intelligence, 1, 15, 1, optionCondition7, onSelect7, onApply7, descriptionText7);

            List<SkillObject> Skills8 = new List<SkillObject>();
            Skills8.Add(DefaultSkills.OneHanded);
            Skills8.Add(DefaultSkills.Tactics);
            TextObject text8 = new TextObject("Learn swordsmanship from an old veteran");
            CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(YouthVCSquireOnConsequence);
            CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText8 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text8, Skills8, CharacterAttributesEnum.Vigor, 1, 10, 1, optionCondition8, onSelect8, onApply8, descriptionText8);

            List<SkillObject> Skills9 = new List<SkillObject>();
            Skills9.Add(DefaultSkills.Riding);
            Skills9.Add(DefaultSkills.Bow);
            TextObject text9 = new TextObject("Hunt local game from horseback");
            CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(YouthHuntOnConsequence);
            CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText9 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text9, Skills9, CharacterAttributesEnum.Control, 1, 15, 1, optionCondition9, onSelect9, onApply9, descriptionText9);

            List<SkillObject> Skills10 = new List<SkillObject>();
            Skills10.Add(DefaultSkills.Polearm);
            Skills10.Add(DefaultSkills.Roguery);
            TextObject text10 = new TextObject("Rob caravans with a group of local bandits");
            CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(YouthRobOnConsequence);
            CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText10 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text10, Skills10, CharacterAttributesEnum.Cunning, 1, 10, 1, optionCondition10, onSelect10, onApply10, descriptionText10);

            List<SkillObject> Skills11 = new List<SkillObject>();
            Skills11.Add(DefaultSkills.Charm);
            Skills11.Add(DefaultSkills.OneHanded);
            TextObject text11 = new TextObject("Become a vampires blood slave");
            CharacterCreationOnCondition optionCondition11 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(YouthSlaveOnConsequence);
            CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText11 = new TextObject("-");
            YouthMenuCreationCategory.AddCategoryOption(text11, Skills11, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition11, onSelect11, onApply11, descriptionText11);

            characterCreation.AddNewMenu(YouthMenu);
        }

        public static void AddAdultMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu AdultMenu = new CharacterCreationMenu(new TextObject("{=MafIe9yI}Young Adulthood"), new TextObject("You are almost a man, you have many expectations from life. You have made your choice and you decide to.."), new CharacterCreationOnInit(AdultOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory AdultMenuCreationCategory = AdultMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.Steward);
            Skills0.Add(DefaultSkills.Tactics);
            TextObject text0 = new TextObject("Enlist with the State troops");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(AdultStateTroopOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Social, 1, 15, 1, optionCondition0, onSelect0, onApply0, descriptionText0);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.Riding);
            Skills1.Add(DefaultSkills.Polearm);
            TextObject text1 = new TextObject("Become a novitiate of the Colleges of Magic");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(AdultNovitiateOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Endurance, 1, 20, 1, optionCondition1, onSelect1, onApply1, descriptionText1);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.Crossbow);
            Skills2.Add(DefaultSkills.Engineering);
            TextObject text2 = new TextObject("Become a novice engineer at the college of Nuln");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(AdultEngineerOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Intelligence, 1, 15, 1, optionCondition2, onSelect2, onApply2, descriptionText2);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Riding);
            TextObject text3 = new TextObject("Join a company of Free Militia");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(AdultMilitiaOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition3, onSelect3, onApply3, descriptionText3);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Polearm);
            Skills4.Add(DefaultSkills.OneHanded);
            TextObject text4 = new TextObject("Provide protection to caravans and pilgrims");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(EmpireCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(AdultProtectionOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Vigor, 1, 20, 1, optionCondition4, onSelect4, onApply4, descriptionText4);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Bow);
            Skills5.Add(DefaultSkills.OneHanded);
            TextObject text5 = new TextObject("Joined the ranks of the local huntsmen");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(AdultHuntsmenOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Control, 1, 15, 1, optionCondition5, onSelect5, onApply5, descriptionText5);

            List<SkillObject> Skills6 = new List<SkillObject>();
            Skills6.Add(DefaultSkills.Athletics);
            TextObject text6 = new TextObject("Set out to discover the old world");
            CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(AdultDiscoverOnConsequence);
            CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(AttributePoint);
            TextObject descriptionText6 = new TextObject("(1 unassigned attribute point)");
            AdultMenuCreationCategory.AddCategoryOption(text6, Skills6, CharacterAttributesEnum.Control, 2, 15, 0, optionCondition6, onSelect6, onApply6, descriptionText6);

            List<SkillObject> Skills7 = new List<SkillObject>();
            Skills7.Add(DefaultSkills.Steward);
            Skills7.Add(DefaultSkills.Tactics);
            TextObject text7 = new TextObject("joined a empire general staff");
            CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(AdultGeneralOnConsequence);
            CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText7 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text7, Skills7, CharacterAttributesEnum.Cunning, 1, 15, 1, optionCondition7, onSelect7, onApply7, descriptionText7);

            List<SkillObject> Skills8 = new List<SkillObject>();
            Skills8.Add(DefaultSkills.Riding);
            Skills8.Add(DefaultSkills.Polearm);
            TextObject text8 = new TextObject("Tended to the horses of travellers and soldiers");
            CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(AdultHorsesOnConsequence);
            CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText8 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text8, Skills8, CharacterAttributesEnum.Endurance, 1, 20, 1, optionCondition8, onSelect8, onApply8, descriptionText8);

            List<SkillObject> Skills9 = new List<SkillObject>();
            Skills9.Add(DefaultSkills.Crossbow);
            Skills9.Add(DefaultSkills.Engineering);
            TextObject text9 = new TextObject("Enlist with the local militia");
            CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(AdultVCMilitiaOnConsequence);
            CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText9 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text9, Skills9, CharacterAttributesEnum.Intelligence, 1, 15, 1, optionCondition9, onSelect9, onApply9, descriptionText9);

            List<SkillObject> Skills10 = new List<SkillObject>();
            Skills10.Add(DefaultSkills.Riding);
            TextObject text10 = new TextObject("rode with the outriders");
            CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(AdultOutridersOnConsequence);
            CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText10 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text10, Skills10, CharacterAttributesEnum.Endurance, 1, 15, 1, optionCondition10, onSelect10, onApply10, descriptionText10);

            List<SkillObject> Skills11 = new List<SkillObject>();
            Skills11.Add(DefaultSkills.Polearm);
            Skills11.Add(DefaultSkills.OneHanded);
            TextObject text11 = new TextObject("Trained alongside the local State Troops");
            CharacterCreationOnCondition optionCondition11 = new CharacterCreationOnCondition(VCCondition);
            CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(AdultTrainedOnConsequence);
            CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText11 = new TextObject("-");
            AdultMenuCreationCategory.AddCategoryOption(text11, Skills11, CharacterAttributesEnum.Vigor, 1, 20, 1, optionCondition11, onSelect11, onApply11, descriptionText11);

            characterCreation.AddNewMenu(AdultMenu);
        }

        public static void AddAchievementMenu(CharacterCreation characterCreation)
        {
            CharacterCreationMenu AchievementMenu = new CharacterCreationMenu(new TextObject("Biggest Achievemen"), new TextObject("before you set out for a life of adventure, your biggest achievement was."), new CharacterCreationOnInit(AchievementOnInit), (CharacterCreationMenu.MenuTypes)0);

            CharacterCreationCategory AchievementMenuCreationCategory = AchievementMenu.AddMenuCategory();

            List<SkillObject> Skills0 = new List<SkillObject>();
            Skills0.Add(DefaultSkills.OneHanded);
            Skills0.Add(DefaultSkills.TwoHanded);
            List<TraitObject> traits0 = new List<TraitObject>();
            traits0.Add(DefaultTraits.Valor);
            TextObject text0 = new TextObject("you defeated an enemy in battle");
            CharacterCreationOnCondition optionCondition0 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect0 = new CharacterCreationOnSelect(AchievementBattleOnConsequence);
            CharacterCreationApplyFinalEffects onApply0 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText0 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text0, Skills0, CharacterAttributesEnum.Vigor, 1, 10, 1, optionCondition0, onSelect0, onApply0, descriptionText0, traits0, 1, 20);

            List<SkillObject> Skills1 = new List<SkillObject>();
            Skills1.Add(DefaultSkills.Tactics);
            Skills1.Add(DefaultSkills.Leadership);
            List<TraitObject> traits1 = new List<TraitObject>();
            traits1.Add(DefaultTraits.Calculating);
            TextObject text1 = new TextObject("you led a successful manhunt");
            CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(AchievementManhuntOnConsequence);
            CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText1 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text1, Skills1, CharacterAttributesEnum.Cunning, 1, 10, 1, optionCondition1, onSelect1, onApply1, descriptionText1, traits1, 1, 10);

            List<SkillObject> Skills2 = new List<SkillObject>();
            Skills2.Add(DefaultSkills.Trade);
            Skills2.Add(DefaultSkills.Crafting);
            List<TraitObject> traits2 = new List<TraitObject>();
            traits2.Add(DefaultTraits.Calculating);
            TextObject text2 = new TextObject("you invested some money in land");
            CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(AchievementInvestOnConsequence);
            CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText2 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text2, Skills2, CharacterAttributesEnum.Intelligence, 1, 10, 1, optionCondition2, onSelect2, onApply2, descriptionText2, traits2, 1, 10);

            List<SkillObject> Skills3 = new List<SkillObject>();
            Skills3.Add(DefaultSkills.Bow);
            Skills3.Add(DefaultSkills.Crossbow);
            TextObject text3 = new TextObject("you hunted dangerous animal");
            CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(AchievementHuntOnConsequence);
            CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText3 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text3, Skills3, CharacterAttributesEnum.Control, 1, 10, 1, optionCondition3, onSelect3, onApply3, descriptionText3, renownToAdd: 5);

            List<SkillObject> Skills4 = new List<SkillObject>();
            Skills4.Add(DefaultSkills.Athletics);
            Skills4.Add(DefaultSkills.Roguery);
            List<TraitObject> traits4 = new List<TraitObject>();
            traits4.Add(DefaultTraits.Valor);
            TextObject text4 = new TextObject("you had famous escapade in town");
            CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(AchievementEscapadeOnConsequence);
            CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText4 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text4, Skills4, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition4, onSelect4, onApply4, descriptionText4, traits4, 1, 5);

            List<SkillObject> Skills5 = new List<SkillObject>();
            Skills5.Add(DefaultSkills.Charm);
            Skills5.Add(DefaultSkills.Steward);
            List<TraitObject> traits5 = new List<TraitObject>();
            traits5.Add(DefaultTraits.Mercy);
            traits5.Add(DefaultTraits.Generosity);
            traits5.Add(DefaultTraits.Honor);
            TextObject text5 = new TextObject("you treated people well");
            CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(AllCondition);
            CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(AchievementPeopleOnConsequence);
            CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(NoEffect);
            TextObject descriptionText5 = new TextObject("-");
            AchievementMenuCreationCategory.AddCategoryOption(text5, Skills5, CharacterAttributesEnum.Endurance, 1, 10, 1, optionCondition5, onSelect5, onApply5, descriptionText5, traits5, 1, 5);

            characterCreation.AddNewMenu(AchievementMenu);
        }

        private static void AchievementPeopleOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AchievementEscapadeOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AchievementHuntOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AchievementInvestOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AchievementManhuntOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AchievementBattleOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultTrainedOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultOutridersOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultVCMilitiaOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultHorsesOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultGeneralOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AttributePoint(CharacterCreation charInfo)
        {
            Hero.MainHero.HeroDeveloper.UnspentAttributePoints += 1;
        }

        private static void AdultDiscoverOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultHuntsmenOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultProtectionOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultMilitiaOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultEngineerOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultNovitiateOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdultStateTroopOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthSlaveOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthRobOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthHuntOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthApprenticeOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthVCSquireOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthHuntsmenOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthAttendeeOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthMerchantOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthMilitiamenOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthSquireOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void YouthGuardOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodHorseOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodPeopleOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodNumbersOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodDetailOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodBrawnOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ChildhoodLeadershipOnConsequence(CharacterCreation charInfo)
        {
        }

        private static bool AllCondition()
        {
            return true;
        }

        private static void AdolescenceWoodsmenOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceFrogwivesOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceStableboyOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceGravediggerOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceMorrOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceCourtOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceHunterOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescencePriestessOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceEngineerOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceBlacksmithOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceVillageMilitiaOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void AdolescenceAttendantOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentFishermanOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentWoodsmanOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentPriestofMorrOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentStirlandMerchantOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentNecromancerOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentVampiricNobleOnConsequence(CharacterCreation charInfo)
        {
        }

        private static bool VCCondition()
        {
            return cc.GetSelectedCulture().StringId == "khuzait";
        }

        private static void ParentThiefOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentHunterOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentBlacksmithOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentEngineerOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentMerchantOnConsequence(CharacterCreation charInfo)
        {
        }

        private static void ParentCaptainOnConsequence(CharacterCreation charInfo)
        {
        }

        private static bool EmpireCondition()
        {
            return cc.GetSelectedCulture().StringId == "empire";
        }

        private static void NoEffect(CharacterCreation charInfo)
        {
        }

        private static void ParentsOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenMounts();
            characterCreation.ClearFaceGenPrefab();
            FaceGenChar mother;
            FaceGenChar father;

            BodyProperties player = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            BodyProperties motherBodyProperties = player;
            BodyProperties fatherBodyProperties = player;
            FaceGen.GenerateParentKey(player, ref motherBodyProperties, ref fatherBodyProperties);
            motherBodyProperties = new BodyProperties(new DynamicBodyProperties(33f, 0.3f, 0.2f), motherBodyProperties.StaticProperties);
            fatherBodyProperties = new BodyProperties(new DynamicBodyProperties(33f, 0.5f, 0.5f), fatherBodyProperties.StaticProperties);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            mother = new FaceGenChar(motherBodyProperties, characterObject1.Equipment, true, "anim_mother_1");
            father = new FaceGenChar(fatherBodyProperties, characterObject2.Equipment, false, "anim_father_1");

            CharacterCreation characterCreation1 = characterCreation;
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            faceGenCharList.Add(mother);
            faceGenCharList.Add(father);
            characterCreation1.ChangeFaceGenChars(faceGenCharList);
            ChangeParentsOutfit(characterCreation);
            ChangeParentsAnimation(characterCreation);
        }

        private static void ChildhoodOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 6f);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, (CharacterObject.PlayerCharacter.IsFemale ? characterObject1.Equipment : characterObject2.Equipment), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(faceGenCharList);
            characterCreation.ChangeCharsAnimation(new List<string>()
            {
                "act_childhood_schooled"
            });
            characterCreation.ClearFaceGenMounts();
        }
        private static void AdolescenceOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 12f);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, (CharacterObject.PlayerCharacter.IsFemale ? characterObject1.Equipment : characterObject2.Equipment), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(faceGenCharList);
            characterCreation.ChangeCharsAnimation(new List<string>()
            {
                "act_childhood_schooled"
            });
            characterCreation.ClearFaceGenMounts();
        }

        private static void YouthOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 16f);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, (CharacterObject.PlayerCharacter.IsFemale ? characterObject1.Equipment : characterObject2.Equipment), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(faceGenCharList);
            characterCreation.ChangeCharsAnimation(new List<string>()
            {
                "act_childhood_schooled"
            });
            characterCreation.ClearFaceGenMounts();
        }

        private static void AdultOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 18f);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, (CharacterObject.PlayerCharacter.IsFemale ? characterObject1.Equipment : characterObject2.Equipment), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(faceGenCharList);
            characterCreation.ChangeCharsAnimation(new List<string>()
            {
                "act_childhood_schooled"
            });
            characterCreation.ClearFaceGenMounts();
        }

        private static void AchievementOnInit(CharacterCreation characterCreation)
        {
            characterCreation.ClearFaceGenPrefab();
            List<FaceGenChar> faceGenCharList = new List<FaceGenChar>();
            BodyProperties originalBodyProperties = CharacterObject.PlayerCharacter.GetBodyProperties(CharacterObject.PlayerCharacter.Equipment, -1);
            originalBodyProperties = FaceGen.GetBodyPropertiesWithAge(ref originalBodyProperties, 21f);
            CharacterObject characterObject1 = Game.Current.ObjectManager.GetObject<CharacterObject>("village_woman_empire");
            CharacterObject characterObject2 = Game.Current.ObjectManager.GetObject<CharacterObject>("townsman_empire");
            faceGenCharList.Add(new FaceGenChar(originalBodyProperties, (CharacterObject.PlayerCharacter.IsFemale ? characterObject1.Equipment : characterObject2.Equipment), CharacterObject.PlayerCharacter.IsFemale, "act_childhood_schooled"));
            characterCreation.ChangeFaceGenChars(faceGenCharList);
            characterCreation.ChangeCharsAnimation(new List<string>()
            {
                "act_childhood_schooled"
            });
            characterCreation.ClearFaceGenMounts();
        }

        private static void ChangeParentsAnimation(CharacterCreation characterCreation)
        {
        }

        private static void ChangeParentsOutfit(CharacterCreation characterCreation)
        {
        }
    }
}
