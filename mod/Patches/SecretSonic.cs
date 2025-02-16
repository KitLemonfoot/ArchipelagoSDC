using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ArchipelagoSDC.Patches{
	
	//Patch to prevent the Heron from picking up worms in the fountain if AP hasn't recieved enough.
	[HarmonyPatch(typeof(SecretSonic), "OnTriggerEnter")]
	class SecretSonic_OnTriggerEnter_Patch{
		public static bool Prefix(SecretSonic __instance, Collider other){
			if (!__instance.hasWorm && other.name.Equals("worm")){
				if(ItemHandler.CurrentWorms<ItemHandler.WormsToNextCheck){
					Debug.Log("Can't pick up worm: not enough AP worms.");
					return false;
				}
			}
			return true;
		}
	}
	
	//Patches to handle Speed and Search powerups.
	[HarmonyPatch(typeof(SecretSonic), "Start")]
	class SecretSonic_StartPre_Patch{
		public static bool Prefix(SecretSonic __instance){
			__instance.ascensionsToUnlockSpeed = 0;
			__instance.ascensionsToUnlockSearch = 0;
			return true;
		}
	}
	
	[HarmonyPatch(typeof(SecretSonic), "Start")]
	class SecretSonic_Start_Patch{
		public static void Postfix(SecretSonic __instance){
			//Speed power
			if(ItemHandler.FlagLookup[12]==false){
				Traverse.Create(__instance).Field("speedUnlocked").SetValue(false);
				__instance.speedButton.color = Color.gray;
			}
			//Search power
			if(ItemHandler.FlagLookup[13]==false){
				Traverse.Create(__instance).Field("searchUnlocked").SetValue(false);
				__instance.speedButton.color = Color.gray;
			}
		}
	}
}