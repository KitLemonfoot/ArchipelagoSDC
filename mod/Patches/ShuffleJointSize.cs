using HarmonyLib;
using UnityEngine;

//Check list for Make My Sonic.

namespace ArchipelagoSDC.Patches{
	
	//Head
	[HarmonyPatch(typeof(ShuffleJointSize), "ShuffleHead")]
	class ShuffleJointSize_ShuffleHead_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_h");
			return true;
		}
	}
	
	//Arms
	[HarmonyPatch(typeof(ShuffleJointSize), "Shuffle")]
	class ShuffleJointSize_Shuffle_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_a");
			return true;
		}
	}
	
	//Legs
	[HarmonyPatch(typeof(ShuffleJointSize), "ShuffleFeet")]
	class ShuffleJointSize_ShuffleFeet_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_l");
			return true;
		}
	}
	
	//Body Color
	[HarmonyPatch(typeof(ShuffleJointSize), "ShuffleColor")]
	class ShuffleJointSize_ShuffleColor_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_bc");
			return true;
		}
	}
	
	//BG Color
	[HarmonyPatch(typeof(ShuffleJointSize), "ShuffleBGColor")]
	class ShuffleJointSize_ShuffleBGColor_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_bg");
			return true;
		}
	}
	
	//Ring
	[HarmonyPatch(typeof(ShuffleJointSize), "EmitRing")]
	class ShuffleJointSize_aaa_Patch{
		public static bool Prefix(ShuffleJointSize __instance){
			LocationHandler.CheckLocation("mms_ring");
			return true;
		}
	}
}