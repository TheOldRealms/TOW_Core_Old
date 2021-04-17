using HarmonyLib;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using StoryMode.CharacterCreationContent;

namespace TOW_Core
{
    [HarmonyPatch(typeof(StoryModeCharacterCreationContent), "OnInitialized")]
    internal class CreationMenuPatch
    {
        private static bool Prefix(CharacterCreation characterCreation, StoryModeCharacterCreationContent __instance)
        {
            CharacterCreationStages.AddParentsMenu(characterCreation, __instance);
            CharacterCreationStages.AddChildhoodMenu(characterCreation);
            CharacterCreationStages.AddAdolescenceMenu(characterCreation);
            CharacterCreationStages.AddYouthMenu(characterCreation);
            CharacterCreationStages.AddAdultMenu(characterCreation);
            CharacterCreationStages.AddAchievementMenu(characterCreation);
            return false;
        }
    }
}
