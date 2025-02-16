using System;
using System.Collections.Generic;
using UnityEngine;

//Handle Archipelago locations.

namespace ArchipelagoSDC{
	
	public static class LocationHandler{
		
		//Storage for locations.
		public static Dictionary<string, long> locations = new Dictionary<string, long>();
		public static Action<bool> s => SentCheck;
		
		//MRS's script is a gigantic ifelse chain that Harmony has no hope of ever hooking to.
		//Instead, we can poll the act variable as MRS updates, and send checks that way.
		public static int currentAct = -1;
		
		public static void handleMRSUpdate(int act){
			//Only check if act has changed
			if(act!=currentAct){
				//Set currentAct to new act, and check location
				currentAct=act;
				CheckLocation("mrs_"+act);
			}
		}
		
		public static void CheckLocation(string loc){
			
			if(locations.ContainsKey(loc) && ConnectHandler.Authenticated){
				Debug.Log("Checking location: "+loc);
				ConnectHandler.Session.Locations.CompleteLocationChecksAsync(s, locations[loc]);
			}
			else Debug.Log("Location \"" + loc + "\" does not exist or you are not connected to AP.");
		}
		
		public static void SentCheck(bool t){
		}
	}
	
}