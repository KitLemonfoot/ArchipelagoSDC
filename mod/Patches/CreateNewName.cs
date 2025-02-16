using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Name gen for MMS
	[HarmonyPatch(typeof(CreateNewName), "NewName")]
	class CreateNewName_NewName_Patch{
		public static bool Prefix(CreateNewName __instance){
			LocationHandler.CheckLocation("mms_name");
			return true;
		}
	}
}