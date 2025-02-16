using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Update debugging for MRS
	[HarmonyPatch(typeof(PlayVideo), "PlaySecret")]
	class PlayVideo_PlaySecret_Patch{
		public static bool Prefix(PlayVideo __instance){
			LocationHandler.CheckLocation("mrs_remote");
			return true;
		}
	}
}