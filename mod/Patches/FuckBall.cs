using HarmonyLib;
using UnityEngine;

namespace ArchipelagoSDC.Patches{
	
	//Patch to prevent Fuckball from spawning 
	[HarmonyPatch(typeof(FuckBall), "UnlockFuckball")]
	class FuckBall_UnlockFuckball_Patch{
		public static bool Prefix(FuckBall __instance){
			if(ItemHandler.FlagLookup[11]==true){
				return true;
			}
			return false;
		}
	}
	
}