using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//MRS check for hitting the remote
	[HarmonyPatch(typeof(PlayVideo), "PlaySecret")]
	class PlayVideo_PlaySecret_Patch{
		public static bool Prefix(PlayVideo __instance){
			LocationHandler.CheckLocation("mrs_remote");
			return true;
		}
	}
}