using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;

namespace TOW_Core
{
    [HarmonyPatch(typeof(CharacterCreationCultureVM), MethodType.Constructor, new Type[] { typeof(CultureObject), typeof(Action<CharacterCreationCultureVM>) })]
    public class CultureVMPatch
    {
        private static void Postfix(CultureObject culture, Action<CharacterCreationCultureVM> onSelection, CharacterCreationCultureVM __instance)
        {
            if (culture.StringId == "empire")
            {
                __instance.ShortenedNameText = "Lousy Humie Gits";
                __instance.DescriptionText = "The empire is a vast nation of Men that fights for its survival with each passing day. Ruled over by the Emperor, Karl Franz, the discipline and martial skill of its armies is renowned throughout the Old World. The backbone of the Empire’s military might, and the reason it has endured in a world filled with both brutal savages and bloodthirsty monsters, is its armies of professional soldiers";
                __instance.PositiveEffectText = "+20% party size, access to knightly orders, 20% more xp from training for lower tier units";
            }
            else if (culture.StringId == "khuzait")
            {
                __instance.ShortenedNameText = "Blood Suckerz";
                __instance.DescriptionText = "The Vampire Counts are fiends without equal. They seek to topple the civilisations of the living and supplant them with an Undead empire. Each Vampire is a unique and majestic figure with his own personality, drive and ambition. In contrast, their minions are mindlessly obedient - rank after rank of ragged and dirt-encrusted cadavers forced back to life by their masters' necromantic power";
                __instance.NameText = "Vampire Counts";
                __instance.PositiveEffectText = "+75% party size, access to necromancy, access to blood knight orders";
            }
        }
    }
}
