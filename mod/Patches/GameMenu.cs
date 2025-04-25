using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Handle game lockdown by items. (MMS, EO, SMM)
	[HarmonyPatch(typeof(GameMenu), "SelectGame")]
	class GameMenu_SelectGame_Patch{
		public static bool Prefix(GameMenu __instance, int game){
			if(!ItemHandler.FlagLookup[game]){
				MessageBoxManager.Instance.ShowErrorMessage("This game isn't unlocked!\nYou will need to receive it first.");
				return false;
			}
			return true;
		}
	}
	
	//MRS is the only "OcculusGame" so we only need to check MRS here.
	[HarmonyPatch(typeof(GameMenu), "SelectOcculusGame")]
	class GameMenu_SelectOcculusGame_Patch{
		public static bool Prefix(GameMenu __instance){
			if(!ItemHandler.FlagLookup[3]){
				MessageBoxManager.Instance.ShowErrorMessage("This game isn't unlocked!\nYou will need to receive it first.");
				return false;
			}
			return true;
		}
	}
}