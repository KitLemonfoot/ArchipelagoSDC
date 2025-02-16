using HarmonyLib;
using UnityEngine;
using System;

namespace ArchipelagoSDC.Patches{
	
	//Code for handling EO warmstarting.
	[HarmonyPatch(typeof(WormEater), "Start")]
	class WormEater_Start_Patch{
		public static void Postfix(WormEater __instance){
			//Setup gamestate accordant to AP datastore.
			int stat = (ItemHandler.WormsToNextCheck - 1) % 6;
			Traverse.Create(__instance).Field("wormsEaten").SetValue(stat);
			//If AP tells us to ascend NOW (user quit game before ascension finished), force the Egg Baby to 6 and kickstart ascension process through original code.
			if(ItemHandler.ReadyToAscend==true){
				Debug.Log("AP is telling us we have an ascension ready. Let's go!");
				Traverse.Create(__instance).Field("wormsEaten").SetValue(6);
				__instance.OnFed();
			}
		}
	}
	
	//Handle AP worm eating stuff.
	[HarmonyPatch(typeof(WormEater), "OnFed")]
	class WormEater_OnFed_Patch{
		public static bool Prefix(WormEater __instance){
			//If we get here from the start patch, do NOT handle a check.
			if(ItemHandler.ReadyToAscend==true){
				return true;
			}
			int gameWorm = Convert.ToInt32(Traverse.Create(__instance).Field("wormsEaten").GetValue());
			gameWorm+=1;
			LocationHandler.CheckLocation("eo_a"+ItemHandler.SlatedSegaNetAccount+"w"+gameWorm);
			ItemHandler.WormsToNextCheck+=1;
			ItemHandler.updateDatastore();
			return true;
		}
	}
	
	//Handle AP warmstart ascension.
	[HarmonyPatch(typeof(WormEater), "Ascend")]
	class WormEater_Ascend_Patch{
		public static bool Prefix(WormEater __instance){
			ItemHandler.ReadyToAscend = true;
			ItemHandler.updateDatastore();
			return true;
		}
	}
	
	//Skip upload dialog and handle AP stuff.
	[HarmonyPatch(typeof(WormEater), "ShowAscensionUploadDialog")]
	class WormEater_ShowAscensionUploadDialog_Patch{
		public static bool Prefix(WormEater __instance){
			LocationHandler.CheckLocation("eo_a"+ItemHandler.SlatedSegaNetAccount+"a");
			//If this is our last ascension, goal.
			if(ItemHandler.SlatedSegaNetAccount==ItemHandler.AscensionsToGoal && ConnectHandler.Authenticated){
				Debug.Log("Goal completed!");
				ConnectHandler.SendCompletion();
			}
			ItemHandler.ReadyToAscend = false;
			ItemHandler.SlatedSegaNetAccount+=1;
			ItemHandler.updateDatastore();
			//Since we're skipping ascension window, we have to call SDC's original delegation here
			Application.LoadLevel("secretgamelogin");
			return false;
		}
	}
}