# Sonic Dreams Collection Archipelago Randomizer
This is a BepInEx mod for [Sonic Dreams Collection](https://hedgehog.exposed/) that targets the [Archipelago Multiworld Randomizer](https://archipelago.gg/). 

Please note that this game *is not* and ***will never be*** supported by the main Archipelago team.
This game is not permitted to be run or discussed in the official Archipelago Discord servers under any circumstances.

# What does Archipelago do to Sonic Dreams Collection?
#### GENERAL
- Access to the various games in the collection are behind items. 
	- You will recieve either *Make My Sonic* or *My Roommate Sonic* to start with.
- Access to SegaNet is behind the *SegaNet Adapter* item. 
	- *You do not need to open a SegaNet server instance alongside the game;* a connection will be "faked" once the item is unlocked.
#### MAKE MY SONIC
- Every menu item is a check.
- Every upload to SegaNet is a check. 
	- You will need *SegaNet Accounts* to upload to SegaNet, see EGGMAN ORIGIN below.
#### SONIC MOVIE MAKER
- Access to each individual stage is an item.
	- The DLC stage is unlocked normally, and will be in logic when *My Roommate Sonic* is unlocked.
- Obtaining the level's camera and finishing the level is a check.
- Access to the Fuckball can also be given as an item.
- (Optional) Every item given to Sonic in Stage 4 can be a check.
- (Optional) Every object released by Sonic in Stage 5 can be a check.
#### MY ROOMMATE SONIC
- Every major progression of the story is a check.
- (Optional) Minor progressions of the story can also be checks.
#### EGGMAN ORIGIN
- As with the vanilla game, you will need the *SegaNet Adapter* item to get past the title screen.
- To start a game, you will need a *SegaNet Account*. The amount in the pool is determined by your YAML.
- In order to ascend, you will need 6 *Robust Worm* items. These are your main macguffins to progress.
	- Robust Worms *do not* carry over between accounts. You will need 6 unique Robust Worm items per SegaNet account.
	- If you do not have enough Robust Worms to feed the Egg Baby, the Heron will be unable to pick up new Robust Worms.
- Feeding the Egg Baby a Robust Worm is a check, alongside ascensions themselves.
    - The amount of Robust Worms you have fed to the Egg Baby is saved to your Archipelago slot. 
- Access to the two powerups you gain for completing ascensions (Speed and Search) can also be given as items.

In order to goal, you will need to fully complete all ascensions in Eggman Origin.

# Setup
You will need the following:
- The latest version of Sonic Dreams Collection
- The Archipelago software from [their Releases page](https://github.com/ArchipelagoMW/Archipelago/releases/tag/0.5.1)
- The apworld and patch files from our releases page
- [BepInEx x86 5.4.23.2](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.2) (the game will NOT work with BepInEx 6)
 
### Installing
1. Install BepInEx to a fresh copy of Sonic Dreams Collection. Do not run the game yet.
2. Install the contents of `SDC_Patches.zip` to the BepInEx folder. You should have three folders in the BepInEx folder: `config`, `core`, and `plugins`.
3. Run the game to generate BepInEx's config data. If the mod installed properly, you should be unable to start any of the games.

### APWorld Setup
1.  Install Archipelago and open the Archipelago launcher.
2.  Click "Install APWorld" and select the `sdc.apworld` file to install the Sonic Dreams Collection apworld.
3.  Click on "Generate Template Options" to generate a template YAML file for Sonic Dreams Collection.
4.  Modify the YAML file to your liking and place it in the `Players` folder.

All further instructions can be found in the [official Archipelago Setup Guide](https://archipelago.gg/tutorial/Archipelago/setup/en#on-your-local-installation).


### Connection
1. Start Sonic Dreams Collection.
2. Click the Twitter icon on the top right of the main menu. If the mod installed properly, you should see a "Connect to Archipelago?" window.
3. Enter your Archipelago server's IP and your slot name in the following windows, then click OK. 
4. The game should connect automatically; you can begin playing when you and/or your group are ready.

Note: It is HIGHLY recommended to have the Archipelago Text Client open alongside your game, as there are currently no indicators when you receive an item.

# Building
You will need the latest version of the [.NET SDK](https://dotnet.microsoft.com/download) installed.
- Place your vanilla Sonic Dreams Collection `Assembly-CSharp.dll` and `UnityEngine.UI.dll` in the project's lib folder. Both these dll files can be obtained from the `/SonicDreamsCollection_Data/Managed` folder.
- Ensure that you are building a BepInEx 5 Plugin targeting NET35 and Unity 4.6.6.
- Run `dotnet build`.
- Move the resultant `ArchipelagoSDC.dll`, as well as `Archipelago.MultiClient.Net.dll` and `Newtonsoft.Json.dll` to your BepInEx plugins folder.
- In order to properly connect to Archipelago servers, you will need to install [c-wspp-websocket-sharp](https://github.com/black-sliver/c-wspp-websocket-sharp) instead of the original `websocket-sharp.dll`.

# Known Issues
- AP: The game may have trouble connecting to wss servers.
- AP: There is no password entry screen available. Password-protected Archipelago servers are not able to be connected to at this time.
- AP: Hitching can occur when sending checks.
- EO: Existing savedata can create a "phantom Heron" on the login screen.
- EO: The Egg Baby does not scale properly with AP warmstart.
- SMM: Movie playback on end screen does not render.

# Special Thanks
- **TGRP0** for creating their [ULTRAKILL Archipelago implementation](https://github.com/TRPG0/ArchipelagoULTRAKILL/) that this project *heavily* referenced data and code from
- **Jarno** for creating their [Timespinner Archipelago implementation](https://github.com/Jarno458/TsRandomizer) that I based a lot of the APWorld code off of
- **icsharpcode** for creating [ILSpy](https://github.com/icsharpcode/ILSpy) to decompile the game's C# code
- **black-silver** for creating [c-wspp-websocket-sharp](https://github.com/black-sliver/c-wspp-websocket-sharp) to allow SDC's old version of Unity to connect to wss servers
- **Scrungip** for inspiring me to actually work on this in spite of the unavoidable AP ban
- **Arcane Kids & cyborgDino** for creating the beautifully morbid artpiece that is Sonic Dreams Collection
- **SEGA** for the big blue guy himself