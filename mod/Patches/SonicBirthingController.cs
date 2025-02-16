using UnityEngine;
using HarmonyLib;
using System;

namespace ArchipelagoSDC.Patches{
	
	//Handler for Birthsanity. 
	//I have the same amount of disgust typing that as you had reading that.
	
	[HarmonyPatch(typeof(SonicBirthingController), "GetNextBirthBatch")]
	class SonicBirthingController_GetNextBirthBatch_Patch{
		public static bool Prefix(SonicBirthingController __instance){
			int birthbatch = Convert.ToInt32(Traverse.Create(__instance).Field("_birthBatchIndex").GetValue());
			LocationHandler.CheckLocation("smm_bs"+birthbatch);
			return true;
		}
	}
}