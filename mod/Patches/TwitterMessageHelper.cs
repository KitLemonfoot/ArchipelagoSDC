using HarmonyLib;
using System;
using UnityEngine;

// Using the vestigial Twitter code to facilitate connecting to Archipelago.

namespace ArchipelagoSDC.Patches{
	//Stub the existing Twitter code in SMM to prevent calls to StartAuthProcess
	[HarmonyPatch(typeof(TwitterMessageHelper), "TweetVideo")]
	class TwitterMessageHelper_TweetVideo_Patch{
		public static bool Prefix(TwitterMessageHelper __instance){
			MessageBoxManager.Instance.ShowErrorMessage("No dice bucko, signed Elon");
			return false;
		}
	}
	//Stub the existing Twitter code in MMS to prevent calls to StartAuthProcess
	[HarmonyPatch(typeof(TwitterMessageHelper), "TweetImage")]
	class TwitterMessageHelper_TweetImage_Patch{
		public static bool Prefix(TwitterMessageHelper __instance){
			MessageBoxManager.Instance.ShowErrorMessage("No dice bucko, signed Elon");
			return false;
		}
	}
	
	[HarmonyPatch(typeof(TwitterMessageHelper), "StartAuthProcess")]
	class TwitterMessageHelper_StartAuthProcess_Patch{
		public static bool Prefix(TwitterMessageHelper __instance){
			if(ConnectHandler.Authenticated){
				MessageBoxManager.Instance.ShowYesNoMessage("Archipelago", "Disconnect from Archipelago?", delegate(bool resp1){
					MessageBoxManager.Instance.PopMessageBox();
					if(resp1){
						ConnectHandler.Disconnect();
					}
				});
			}
			else{
				MessageBoxManager.Instance.ShowYesNoMessage("Archipelago", "Connect to Archipelago?", delegate(bool resp1){
					MessageBoxManager.Instance.PopMessageBox();
					if(resp1){
						ConnectHandler.getIP();
					}
				});
			}
			return false;
		}
	}
}