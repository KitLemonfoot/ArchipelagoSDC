using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Eggysanity for SMM.
	//This doesn't handle duplicate names, or Eggies that want you to give them a prop.
	[HarmonyPatch(typeof(MMSecretDialogue), "Show")]
	class MMSecretDialogue_Show_Patch{
		public static void Postfix(MMSecretDialogue __instance, string nameTag){
			LocationHandler.CheckLocation("smm_es_"+nameTag);
		}
	}
	
}