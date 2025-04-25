from typing import List, Optional, Callable
from BaseClasses import CollectionState
from dataclasses import dataclass
from .Regions import Regions, SDCRegion
from .Options import SDCOptions
from .SDCLogic import SDCLogic

@dataclass
class SDCLocation:
    name: str
    region: SDCRegion
    game_id: str
    logic: Optional[Callable[[CollectionState], bool]] = None

def get_location_data(player: Optional[int], options: Optional[SDCOptions]):
    logic = SDCLogic(player, options)

    #Setup base locations.
    locations: List[SDCLocation] = [
        #MMS
        SDCLocation("Make My Sonic - Head", Regions.mms, "mms_h", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Arms", Regions.mms, "mms_a", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Legs", Regions.mms, "mms_l", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Body Color", Regions.mms, "mms_bc", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - BG Color", Regions.mms, "mms_bg", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Sonic Name", Regions.mms, "mms_name", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Ring", Regions.mms, "mms_ring", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Profile Camera", Regions.mms, "mms_cam2", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Behind Camera", Regions.mms, "mms_cam3", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Upper Side Camera", Regions.mms, "mms_cam4", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Front Camera", Regions.mms, "mms_cam0", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Default Camera", Regions.mms, "mms_cam1", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Printable Mode", Regions.mms, "mms_print", lambda state: logic.has_mms(state)),
        SDCLocation("Make My Sonic - Take Screenshot", Regions.mms, "mms_shot", lambda state: logic.has_mms(state)),
        #SMM
        SDCLocation("Sonic Movie Maker - Scenario 1 Camera", Regions.smm, "smm_cam_Backyard", lambda state: logic.has_s1(state)),
        SDCLocation("Sonic Movie Maker - Scenario 2 Camera", Regions.smm, "smm_cam_Prom", lambda state: logic.has_s2(state)),
        SDCLocation("Sonic Movie Maker - Scenario 3 Camera", Regions.smm, "smm_cam_Hotel", lambda state: logic.has_s3(state)),
        SDCLocation("Sonic Movie Maker - Scenario 4 Camera", Regions.smm, "smm_cam_Feeding", lambda state: logic.has_s4(state)),
        SDCLocation("Sonic Movie Maker - Scenario 5 Camera", Regions.smm, "smm_cam_Birthing", lambda state: logic.has_s5(state)),
        SDCLocation("Sonic Movie Maker - Scenario 6 Camera", Regions.smm, "smm_cam_Crib", lambda state: logic.has_s6(state)),
        SDCLocation("Sonic Movie Maker - DLC Scenario Camera", Regions.smm, "smm_cam_Roommates", lambda state: logic.has_dlc(state)),
        SDCLocation("Sonic Movie Maker - Scenario 1 Complete", Regions.smm, "smm_lvlc_Backyard", lambda state: logic.has_s1(state)),
        SDCLocation("Sonic Movie Maker - Scenario 2 Complete", Regions.smm, "smm_lvlc_Prom", lambda state: logic.has_s2(state)),
        SDCLocation("Sonic Movie Maker - Scenario 3 Complete", Regions.smm, "smm_lvlc_Hotel", lambda state: logic.has_s3(state)),
        SDCLocation("Sonic Movie Maker - Scenario 4 Complete", Regions.smm, "smm_lvlc_Feeding", lambda state: logic.has_s4(state)),
        SDCLocation("Sonic Movie Maker - Scenario 5 Complete", Regions.smm, "smm_lvlc_Birthing", lambda state: logic.has_s5(state)),
        SDCLocation("Sonic Movie Maker - Scenario 6 Complete", Regions.smm, "smm_lvlc_Crib", lambda state: logic.has_s6(state)),
        SDCLocation("Sonic Movie Maker - DLC Scenario Complete", Regions.smm, "smm_lvlc_Roommates", lambda state: logic.has_dlc(state)),
        #MRS
        SDCLocation("My Roommate Sonic - Sonic Thumbs Up", Regions.mrs, "mrs_1", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - Respond to Texts", Regions.mrs, "mrs_6", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - Knock It Off", Regions.mrs, "mrs_88", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - The Distraction", Regions.mrs, "mrs_89", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - The Kill", Regions.mrs, "mrs_999", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - Taken Too Far", Regions.mrs, "mrs_6372", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - Remote", Regions.mrs, "mrs_remote", lambda state: logic.has_mrs(state)),
        SDCLocation("My Roommate Sonic - Dreamcast Off", Regions.mrs, "mrs_dcoff", lambda state: logic.has_mrs(state)),
    ]

    #MRSSanity
    if not options or options.mrs_full_story:
        locations += (
            SDCLocation("My Roommate Sonic - Respond to Initial Text", Regions.mrs, "mrs_2", lambda state: logic.has_mrs(state)),
            SDCLocation("My Roommate Sonic - I Don't Believe You", Regions.mrs, "mrs_3", lambda state: logic.has_mrs(state)),
            SDCLocation("My Roommate Sonic - Looking out the Window", Regions.mrs, "mrs_5", lambda state: logic.has_mrs(state)),
            SDCLocation("My Roommate Sonic - Shoe Off", Regions.mrs, "mrs_112", lambda state: logic.has_mrs(state)),
            SDCLocation("My Roommate Sonic - Move In", Regions.mrs, "mrs_8", lambda state: logic.has_mrs(state))
        )
    
    if not options or options.smm_sanity:
        locations += (
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 1", Regions.smm, "smm_fs1", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 2", Regions.smm, "smm_fs2", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 3", Regions.smm, "smm_fs3", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 4", Regions.smm, "smm_fs4", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 5", Regions.smm, "smm_fs5", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 6", Regions.smm, "smm_fs6", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 7", Regions.smm, "smm_fs7", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - Scenario 4 Food Item 8", Regions.smm, "smm_fs8", lambda state: logic.has_s4(state)),
            #SMM Birthsanity
            SDCLocation("Sonic Movie Maker - Scenario 5 Ring", Regions.smm, "smm_bs0", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Scenario 5 Chao", Regions.smm, "smm_bs1", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Scenario 5 Chaos Emerald", Regions.smm, "smm_bs2", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Scenario 5 Text Bubble", Regions.smm, "smm_bs3", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Scenario 5 Tails", Regions.smm, "smm_bs4", lambda state: logic.has_s5(state)),
        )

    #SMM Eggysanity
    if not options or options.smm_eggysanity:
        locations += (
            SDCLocation("Sonic Movie Maker - MASTER", Regions.smm, "smm_es_MASTER", lambda state: logic.has_s2(state)),
            SDCLocation("Sonic Movie Maker - Moon Egg", Regions.smm, "smm_es_Moon Egg", lambda state: logic.has_s3(state)),
            SDCLocation("Sonic Movie Maker - Horned Eggs", Regions.smm, "smm_es_Horned Eggs", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - King", Regions.smm, "smm_es_King", lambda state: logic.has_s4(state)),
            SDCLocation("Sonic Movie Maker - 911 Egg", Regions.smm, "smm_es_911 Egg", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Lonely Egg", Regions.smm, "smm_es_Lonely Egg", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Retired Detective Egg", Regions.smm, "smm_es_Retired Detective Egg", lambda state: logic.has_s5(state)),
            SDCLocation("Sonic Movie Maker - Scared Eggs", Regions.smm, "smm_es_Scared Eggs", lambda state: logic.has_s6(state)),
            SDCLocation("Sonic Movie Maker - Floor Egg", Regions.smm, "smm_es_Floor Egg", lambda state: logic.has_dlc(state)),
            SDCLocation("Sonic Movie Maker - Legal Egg", Regions.smm, "smm_es_Legal Egg", lambda state: logic.has_dlc(state)),
            SDCLocation("Sonic Movie Maker - TV Egg", Regions.smm, "smm_es_TV Egg", lambda state: logic.has_dlc(state)),
        )

    #EO Eggysanity
    if not options or options.eo_eggysanity:
        locations += (
            SDCLocation("Eggman Origin - Behind You", Regions.smm, "eo_es_Behind You", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Curio", Regions.smm, "eo_es_Curio", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Discount", Regions.smm, "eo_es_Discount", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Distant Egg", Regions.smm, "eo_es_Distant Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Egg Rabbi", Regions.smm, "eo_es_Egg Rabbi", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Labor Egg", Regions.smm, "eo_es_Labor Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Lonely Egg", Regions.smm, "eo_es_Lonely Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Miracle", Regions.smm, "eo_es_Miracle", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Naoto", Regions.smm, "eo_es_Naoto", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Old Egg", Regions.smm, "eo_es_Old Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Pessimistic Egg", Regions.smm, "eo_es_Pessimistic Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Spoiled Egg", Regions.smm, "eo_es_Spoiled Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Tired Egg", Regions.smm, "eo_es_Tired Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),
            SDCLocation("Eggman Origin - Wise Egg", Regions.smm, "eo_es_Wise Egg", lambda state: logic.has_full_eo(state) and logic.has_acc(1, state)),         
        )

    #Base EO locations.
    locations += (
        #Base EO locations
        SDCLocation(f"Make My Sonic - Account 1 Upload", Regions.mms, f"mms_a1ul", lambda state: logic.has_seganet_mms(state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 1", Regions.eo, f"eo_a1w1", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(1, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 2", Regions.eo, f"eo_a1w2", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(2, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 3", Regions.eo, f"eo_a1w3", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(3, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 4", Regions.eo, f"eo_a1w4", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(4, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 5", Regions.eo, f"eo_a1w5", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(5, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Worm 6", Regions.eo, f"eo_a1w6", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(6, 1, state) and logic.has_acc(1, state)),
        SDCLocation(f"Eggman Origin - Account 1 Ascension", Regions.eo, f"eo_a1a", lambda state: logic.has_full_eo(state) and logic.has_acc_worms(6, 1, state) and logic.has_acc(1, state))
    )

    #Extended EO stuff.
    if not options or options.ascensions_to_goal>1:
        if not options:
            hiRange = 100
        else:
            hiRange = options.ascensions_to_goal
        for ac in range(2, hiRange+1):
            locations += (
                SDCLocation(f"Make My Sonic - Account {ac} Upload", Regions.mms, f"mms_a{ac}ul", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(0, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 1", Regions.eo, f"eo_a{ac}w1", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(1, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 2", Regions.eo, f"eo_a{ac}w2", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(2, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 3", Regions.eo, f"eo_a{ac}w3", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(3, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 4", Regions.eo, f"eo_a{ac}w4", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(4, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 5", Regions.eo, f"eo_a{ac}w5", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(5, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Worm 6", Regions.eo, f"eo_a{ac}w6", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(6, a, state) and logic.has_acc(a, state)),
                SDCLocation(f"Eggman Origin - Account {ac} Ascension", Regions.eo, f"eo_a{ac}a", lambda state, a=ac: logic.has_full_eo(state) and logic.has_acc_worms(6, a, state) and logic.has_acc(a, state))
            )
    
    return locations


