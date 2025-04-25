using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Eggysanity for EO.
	[HarmonyPatch(typeof(SecretDialogue), "Show")]
	class SecretDialogue_Show_Patch{
		public static void Postfix(SecretDialogue __instance, string nameTag){
			LocationHandler.CheckLocation("eo_es_"+nameTag);
		}
	}
	
}