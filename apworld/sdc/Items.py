from typing import List
from dataclasses import dataclass
from enum import Enum
from BaseClasses import ItemClassification

#I really hope this doesn't conflict
base_id = 4726372

class ItemType(Enum):
    Flag = 0
    SNAcc = 1
    Worm = 2
    Junk = 3

@dataclass
class SDCItem:
    classification: ItemClassification
    name: str
    type: ItemType
    count: int=1

#All the items in the base version of SDC.
#SegaNet accounts and robust worms are generated on the fly.
item_list: List[SDCItem] = [
    #Games
    SDCItem(ItemClassification.progression, "Make My Sonic", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Eggman Origin", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Sonic Movie Maker", ItemType.Flag),
    SDCItem(ItemClassification.progression, "My Roommate Sonic", ItemType.Flag),
    
    #SMM Stages
    SDCItem(ItemClassification.progression, "Backyard", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Prom", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Hotel", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Feeding", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Birthing", ItemType.Flag),
    SDCItem(ItemClassification.progression, "Crib", ItemType.Flag),

    #Other Flags
    SDCItem(ItemClassification.progression, "SegaNet Adapter", ItemType.Flag),
    SDCItem(ItemClassification.useful, "Fuckball", ItemType.Flag),
    SDCItem(ItemClassification.useful, "Speed", ItemType.Flag),
    SDCItem(ItemClassification.useful, "Search", ItemType.Flag),

    #EO Items
    SDCItem(ItemClassification.progression, "Robust Worm", ItemType.Worm),
    SDCItem(ItemClassification.progression, "SegaNet Account", ItemType.SNAcc),

    SDCItem(ItemClassification.filler, "Nothing", ItemType.Junk),

    #Goal item, put here to prevent servers from crashing
    SDCItem(ItemClassification.progression_skip_balancing, "Final Ascension", ItemType.Flag),

]