using HarmonyLib;
using UnityEngine;

namespace ArchipelagoSDC.Patches{
	
	//Force a Seganet "connection" accordant to AP's SegaNet flag.
	[HarmonyPatch(typeof(SecretGameLogin), "OnPlayButton")]
	class SecretGameLogin_OnPlayButton_Patch{
		public static void Postfix(SecretGameLogin __instance){
			if(ItemHandler.FlagLookup[10]==true){
				//Handle SegaNet account.
				if (SecretDataTracker.GetCharacter() != null && (ItemHandler.SegaNetAccounts>=ItemHandler.SlatedSegaNetAccount)){
					__instance.loginButton.SetActive(value: true);
					__instance.errorMessage.SetActive(value: false);
				}
				else{
					__instance.errorMessage.SetActive(value: true);
					__instance.loginButton.SetActive(value: false);
				}
				__instance.noAdapterMessage.SetActive(value: false);
			}
			else{
				//If we don't have a Seganet flag, we shouldn't have any sort of data. Wipe it.
				__instance.loginButton.SetActive(value: false);
				__instance.errorMessage.SetActive(value: false);
				__instance.noAdapterMessage.SetActive(value: true);
			}
		}
	}
	
	//Prevent update from rendering a Sonic if we don't have the SegaNet flag.
	[HarmonyPatch(typeof(SecretGameLogin), "Update")]
	class SecretGameLogin_Update_Patch{
		public static void Postfix(SecretGameLogin __instance){
			if(ItemHandler.FlagLookup[10]==false){
				__instance.character.SetActive(value: false);
				__instance.noCharacterShadow.SetActive(value: true);
				__instance.ascensionPanel.SetActive(value: false);
			}
		}
	}
	
}