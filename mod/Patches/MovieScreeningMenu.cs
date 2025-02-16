using HarmonyLib;
using System;
using UnityEngine;

namespace ArchipelagoSDC.Patches{
	
	//Send check for end trigger
	[HarmonyPatch(typeof(MovieScreeningMenu), "NextLevel")]
	class MovieScreeningMenu_NextLevel_Patch{
		public static bool Prefix(MovieScreeningMenu __instance){
			__instance.BackToMainMenu();
			return false;
		}
	}
}