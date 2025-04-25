using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Packets;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ArchipelagoSDC{
	
	public static class ConnectHandler{
		
		public static bool Authenticated;
        public static ArchipelagoSession Session;
		
		//Using default SDC Twitter prefabs
		private static string TwitterPostPrefabName = "MessageBox/MessageBox_PostTweet";
		private static TwitterPostMessageBox TwitterPostPrefab => Resources.Load(TwitterPostPrefabName, typeof(TwitterPostMessageBox)) as TwitterPostMessageBox;
		
		public static void getIP(){
			
			string APip = null;
			
			MessageBoxConfig messageBoxConfig = new MessageBoxConfig();
			messageBoxConfig.SpecificPrefab = TwitterPostPrefab;
			messageBoxConfig.Title = "Enter Archipelago IP";
			TwitterPostMessageBox messageBox = null;
			Func<string> GetCurrentTweet = () => messageBox.MessageText;
			messageBoxConfig.AddButton("O K", delegate{
				APip = messageBox.MessageText;
				Debug.Log(APip);
				MessageBoxManager.Instance.PopMessageBox();
				getSlotName(APip);
			});
			messageBoxConfig.AddButton("N O", delegate{
				MessageBoxManager.Instance.PopMessageBox();
			});
			messageBox = MessageBoxManager.Instance.ShowMessageBox<TwitterPostMessageBox>(messageBoxConfig);
			messageBox.MessageText = "archipelago.gg:";
			
		}
		
		public static void getSlotName(string APip){
			
			string APslot = null;
			
			//using the twitter one again until I can hack up the ascension dialog to work with slot name
			MessageBoxConfig messageBoxConfig = new MessageBoxConfig();
			messageBoxConfig.SpecificPrefab = TwitterPostPrefab;
			messageBoxConfig.Title = "Enter Slot Name";
			TwitterPostMessageBox messageBox = null;
			Func<string> GetCurrentTweet = () => messageBox.MessageText;
			messageBoxConfig.AddButton("O K", delegate{
				APslot = messageBox.MessageText;
				Debug.Log(APslot);
				MessageBoxManager.Instance.PopMessageBox();
				MessageBox messageBox2 = MessageBoxManager.Instance.ShowBusyMessage("Archipelago", "Connecting to Archipelago. Please wait...");
				ConnectToAP(APip, APslot);
			});
			messageBoxConfig.AddButton("N O", delegate{
				MessageBoxManager.Instance.PopMessageBox();
			});
			messageBox = MessageBoxManager.Instance.ShowMessageBox<TwitterPostMessageBox>(messageBoxConfig);
			messageBox.MessageText = "SDCPlayer";
			
			
		}
		
		public static void ConnectToAP(string APserver, string slot){
			LoginResult result;
			try{
				Session = ArchipelagoSessionFactory.CreateSession(APserver.ToString());
				Session.Items.ItemReceived += ItemReceived;
				
				result = Session.TryConnectAndLogin(
					"Sonic Dreams Collection", 
					slot, 
					ItemsHandlingFlags.AllItems,
					new Version(0,5,0),
					null,
					null,
					null,
					true
				);
				Debug.Log(Session.ToString());
			}
			catch (Exception e){
				result = new LoginFailure(e.GetBaseException().Message);
			}
			MessageBoxManager.Instance.PopMessageBox();
			if(result is LoginSuccessful loginSuccess){
				Debug.Log("Successfully connected to server, setting up...");
				Authenticated = true;
				
				//Pull goal amount
				ItemHandler.AscensionsToGoal = int.Parse(loginSuccess.SlotData["AscensionsToGoal"].ToString());
				//Location data
				LocationHandler.locations = ((JObject)loginSuccess.SlotData["locations"]).ToObject<Dictionary<string, long>>();
				//Check start location
				//LocationHandler.CheckLocation("start");
				//Manage datastore
				Session.DataStorage[Scope.Slot,"SlatedSegaNetAccount"].Initialize(1);
				Session.DataStorage[Scope.Slot,"WormsToNextCheck"].Initialize(1);
				Session.DataStorage[Scope.Slot,"ReadyToAscend"].Initialize(false);
				Session.DataStorage[Scope.Slot,"MRSComplete"].Initialize(false);
				ItemHandler.pullDatastore();
				
				//Reset and setup save file
				PlayerPrefs.SetInt("numascended", Session.DataStorage[Scope.Slot,"SlatedSegaNetAccount"]-1);
				if(Session.DataStorage[Scope.Slot,"MRSComplete"]){
					PlayerPrefs.SetInt("displayedUnlockMessage", 1);
					PlayerPrefs.SetInt("beatroommate", 1);
				}
				else{
					PlayerPrefs.SetInt("displayedUnlockMessage", 0);
					PlayerPrefs.SetInt("beatroommate", 0);
				}
				
				MessageBoxManager.Instance.ShowErrorMessage("It worked, good luck have fun");
			}
			else if(result is LoginFailure failure){
				string errorMessage = $"Failed to connect to Archipelago.\n";
				foreach (ConnectionRefusedError error in failure.ErrorCodes){
					errorMessage += $"{error}: ";
				}
				foreach (string error in failure.Errors){
					errorMessage += $"{error}";
				}
				Session.Socket.Disconnect();
				MessageBoxManager.Instance.ShowErrorMessage(errorMessage);
                Session = null;
				return;
			}
			
		}
		
		public static void TryGetSlotDataValue(ref string option, Dictionary<string, object> slotData, string key, string defaultValue)
        {
            try { option = slotData[key].ToString(); }
            catch (KeyNotFoundException)
            {
                Debug.Log("");
                option = defaultValue;
            }
        }
		
		public static void ItemReceived(ReceivedItemsHelper helper){
			ItemInfo item = helper.PeekItem();
			string name = item.ItemName;
			ItemHandler.recieveItem(name);
			helper.DequeueItem();
		}
		
		public static void Disconnect(){
			if (Session != null && Session.Socket != null) Session.Socket.Disconnect();
			Session = null;
			Authenticated = false;
			ItemHandler.wipeItems();
			MessageBoxManager.Instance.ShowErrorMessage("It worked, see ya later");
		}
		
		public static void SendCompletion()
        {
            Session?.SetGoalAchieved();
        }
	}
	
}