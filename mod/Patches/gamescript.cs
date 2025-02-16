using HarmonyLib;
using UnityEngine;
using System;

namespace ArchipelagoSDC.Patches{
	
	//Update debugging for MRS
	[HarmonyPatch(typeof(gamescript), "Update")]
	class gamescript_Update_Patch{
		public static bool Prefix(gamescript __instance){
			int act = Convert.ToInt32(Traverse.Create(__instance).Field("act").GetValue());
			LocationHandler.handleMRSUpdate(act);
			return true;
		}
	}
}