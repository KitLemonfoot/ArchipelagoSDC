using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Handle end of MRS, update datastore so MRS complete message shows up properly
	[HarmonyPatch(typeof(Roommates_Finger), "EndGame")]
	class Roommates_Finger_EndGame_Patch{
		public static bool Prefix(Roommates_Finger __instance){
			LocationHandler.CheckLocation("mrs_dcoff");
			ItemHandler.MRSComplete = true;
			ItemHandler.updateDatastore();
			return true;
		}
	}
}