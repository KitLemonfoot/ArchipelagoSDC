using HarmonyLib;
using UnityEngine;
using System;

namespace ArchipelagoSDC.Patches{
	
	//Handle Seganet in MMS.
	[HarmonyPatch(typeof(CustomizerMenu), "Error")]
	class CustomizerMenu_Error_Patch{
		public static bool Prefix(CustomizerMenu __instance){
			if(ItemHandler.FlagLookup[10]==true && (ItemHandler.SegaNetAccounts>=ItemHandler.SlatedSegaNetAccount)){
				__instance.UploadMenu();
				return false;
			}
			return true;
		}
	}
	
	//Checks for MMS
	//Printable
	[HarmonyPatch(typeof(CustomizerMenu), "ToggleColoringBook")]
	class CustomizerMenu_ToggleColoringBook_Patch{
		public static bool Prefix(CustomizerMenu __instance){
			LocationHandler.CheckLocation("mms_print");
			return true;
		}
	}
	
	//Screenshot
	[HarmonyPatch(typeof(CustomizerMenu), "TakeScreenshot")]
	class CustomizerMenu_TakeScreenshot_Patch{
		public static bool Prefix(CustomizerMenu __instance){
			LocationHandler.CheckLocation("mms_shot");
			return true;
		}
	}
	
	//Camera function
	[HarmonyPatch(typeof(CustomizerMenu), "NextScreenCam")]
	class CustomizerMenu_NextScreenCam_Patch{
		public static void Postfix(CustomizerMenu __instance){
			string csi = Convert.ToString(Traverse.Create(__instance).Field("camScreenIndex").GetValue());
			LocationHandler.CheckLocation("mms_cam"+csi);
		}
	}
	
	//Screenshot
	[HarmonyPatch(typeof(CustomizerMenu), "UploadOK")]
	class CustomizerMenu_UploadOK_Patch{
		public static bool Prefix(CustomizerMenu __instance){
			LocationHandler.CheckLocation("mms_a"+ItemHandler.SlatedSegaNetAccount+"ul");
			return true;
		}
	}
}