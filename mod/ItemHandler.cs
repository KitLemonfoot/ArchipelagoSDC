using System;
using UnityEngine;
using Archipelago.MultiClient.Net.Enums;

//Handle Archipelago items.

namespace ArchipelagoSDC{
	
	public static class ItemHandler{
		
		//I should use an enum or something more sophisticated for this, but eh
		public static string[] FlagNames = {
			"Make My Sonic",
			"Eggman Origin",
			"Sonic Movie Maker",
			"My Roommate Sonic",
			"Backyard",
			"Prom",
			"Hotel",
			"Feeding",
			"Birthing",
			"Crib",
			"SegaNet Adapter",
			"Fuckball",
			"Speed",
			"Search"
		};
		public static bool[] FlagLookup = {
			false, //MMS
			false, //EO
			false, //SMM
			false, //MRS
			false, //S1
			false, //S2
			false, //S3
			false, //S4
			false, //S5
			false, //S6
			false, //SNET
			false, //FBALL
			false, //SPD
			false//SRCH
		};
		
		//SegaNet variables.
		//THESE SHOULD ALWAYS COME FROM AP.
		public static int SegaNetAccounts = 0;
		public static int CurrentWorms = 0;
		//AP Datastore
		public static int SlatedSegaNetAccount = 1;
		public static int WormsToNextCheck = 1;
		public static bool ReadyToAscend = false;
		public static bool MRSComplete = false;
		//AP Slotdata
		public static int AscensionsToGoal = 1;
		
		public static void recieveItem(string itemName){
			//Base itemlist.
			int idx = Array.IndexOf(FlagNames, itemName);
			if(idx!=-1){
				FlagLookup[idx]=true;
				return;
			}
			//Other items
			switch(itemName){
				case "SegaNet Account": SegaNetAccounts++;break;
				case "Robust Worm": CurrentWorms++;break;
				case "Nothing": break;
				default: Debug.Log("Invalid item "+itemName+", ignoring.");break;
			}
		}
		
		public static void pullDatastore(){
			if(ConnectHandler.Authenticated){
				SlatedSegaNetAccount = ConnectHandler.Session.DataStorage[Scope.Slot,"SlatedSegaNetAccount"];
				WormsToNextCheck = ConnectHandler.Session.DataStorage[Scope.Slot,"WormsToNextCheck"];
				ReadyToAscend = ConnectHandler.Session.DataStorage[Scope.Slot,"ReadyToAscend"];
				MRSComplete = ConnectHandler.Session.DataStorage[Scope.Slot,"MRSComplete"];
			}
			else{
				Debug.Log("Not connected to AP, can't pull datastore.");
			}
		}
		
		public static void updateDatastore(){
			if(ConnectHandler.Authenticated){
				ConnectHandler.Session.DataStorage[Scope.Slot,"SlatedSegaNetAccount"] = SlatedSegaNetAccount;
				ConnectHandler.Session.DataStorage[Scope.Slot,"WormsToNextCheck"] = WormsToNextCheck;
				ConnectHandler.Session.DataStorage[Scope.Slot,"ReadyToAscend"] = ReadyToAscend;
				ConnectHandler.Session.DataStorage[Scope.Slot,"MRSComplete"] = MRSComplete;
			}
			else{
				Debug.Log("Not connected to AP, skipping datastore update.");
			}
			
		}
		
	}
}