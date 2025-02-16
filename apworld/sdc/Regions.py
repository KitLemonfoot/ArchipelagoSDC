from typing import List
from dataclasses import dataclass

@dataclass
class SDCRegion:
    short_name: str
    full_name: str

class Regions:
    mms = SDCRegion("mms", "Make My Sonic")
    eo = SDCRegion("eo", "Eggman Origin")
    smm = SDCRegion("smm", "Sonic Movie Maker")
    mrs = SDCRegion("mrs", "My Roommate Sonic")

    all_regions: List[SDCRegion] = [
        mms, eo, smm, mrs
    ]