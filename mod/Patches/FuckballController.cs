using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ArchipelagoSDC.Patches{
	
	//Patch to prevent Fuckball from spawning 
	[HarmonyPatch(typeof(FuckballController), "Start")]
	class FuckballController_Start_Patch{
		public static bool Prefix(FuckballController __instance){
			if(ItemHandler.FlagLookup[11]==true){
				SecretDataTracker.SetHasFuckball(has: true);
				return true;
			}
			__instance.fuckballIcon.color = Color.clear;
			return false;
		}
	}
	
	[HarmonyPatch(typeof(FuckballController), "TrySpawnFuckball")]
	class FuckballController_TrySpawnFuckball_Patch{
		public static bool Prefix(FuckballController __instance){
			if(ItemHandler.FlagLookup[11]==true){
				return true;
			}
			return false;
		}
	}
	
}