using HarmonyLib;
using UnityEngine;

namespace ArchipelagoSDC.Patches{
	
	//Patch to prevent the Heron from picking up worms if AP hasn't recieved enough.
	[HarmonyPatch(typeof(SecretWorm), "OnPing")]
	class SecretWorm_OnPing_Patch{
		public static bool Prefix(SecretWorm __instance){
			if(ItemHandler.CurrentWorms<ItemHandler.WormsToNextCheck){
				Debug.Log("Can't ping worm: not enough AP worms.");
				return false;
			}
			return true;
		}
	}
}