using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Stub the original SegaNet connectivity so that we don't send messages, and to prevent overriding AP's SegaNet handlers.
	[HarmonyPatch(typeof(Seganet), "TryToConnect")]
	class Seganet_TryToConnect_Patch{
		public static bool Prefix(Seganet __instance){
			return false;
		}
	}
}