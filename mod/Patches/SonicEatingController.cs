using HarmonyLib;
using System;

namespace ArchipelagoSDC.Patches{
	
	//Handler for Foodsanity. 
	
	[HarmonyPatch(typeof(SonicEatingController), "UpdateFoodAmount")]
	class SonicEatingController_UpdateFoodAmount_Patch{
		public static bool Prefix(SonicEatingController __instance){
			int foodamount = Convert.ToInt32(Traverse.Create(__instance).Field("_currentFoodAmount").GetValue());
			LocationHandler.CheckLocation("smm_fs"+foodamount);
			return true;
		}
	}
}