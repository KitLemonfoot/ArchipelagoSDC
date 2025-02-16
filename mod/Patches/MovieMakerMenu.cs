using HarmonyLib;
using System;
using UnityEngine;

namespace ArchipelagoSDC.Patches{
	
	//Hijack button states and pull from AP items.
	//Kind of an ugly hack, but it'll do
	[HarmonyPatch(typeof(MovieMakerMenu), "SetButtonStates")]
	class MovieMakerMenu_SetButtonStates_Patch{
		public static bool Prefix(MovieMakerMenu __instance){
			for (int i = 0; i < 6; i++){
				if(ItemHandler.FlagLookup[i+4]){
					MovieMakerSaveManager.SetLevelUnlocked(i+1);
				}
				else{
					MovieMakerSaveManager.ClearLevelData(i+1);
				}
			}
			return true;
		}
	}
}