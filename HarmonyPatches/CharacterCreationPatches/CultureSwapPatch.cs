using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;

namespace TOW_Core
{
    [HarmonyPatch(typeof(CharacterCreationCultureStageVM), "SortCultureList")]
    public class CultureSwapPatch
    {
        private static bool Prefix(MBBindingList<CharacterCreationCultureVM> listToWorkOn)
        {
            return false;
        }
    }
}
