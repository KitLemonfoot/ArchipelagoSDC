using HarmonyLib;

namespace ArchipelagoSDC.Patches{
	
	//Detect when we pick up the camera in the level
	[HarmonyPatch(typeof(ControllerCamera), "SetCameraEnabled")]
	class ControllerCamera_SetCameraEnabled_Patch{
		public static void Postfix(ControllerCamera __instance, bool camEnabled){
			if(camEnabled){
				//this is a messy way to do this but w/e
				string scen = MovieMakerMenu.NextScenario.Name;
				LocationHandler.CheckLocation("smm_cam_"+scen);
			}
		}
	}
	
	//Detect when we finish the level.
	//Easier to do it here since MovieMakerGameController.EndScenario calls this function anyways.
	[HarmonyPatch(typeof(ControllerCamera), "SaveMovie")]
	class ControllerCamera_SaveMovie_Patch{
		public static bool Prefix(ControllerCamera __instance){
			string scen = MovieMakerMenu.NextScenario.Name;
			LocationHandler.CheckLocation("smm_lvlc_"+scen);
			return true;
		}
	}
}