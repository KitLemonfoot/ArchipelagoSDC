from dataclasses import dataclass
from Options import Toggle, Range, PerGameCommonOptions

class MRSFullStory(Toggle):
    """
    Adds a few extra locations in My Roommate Sonic, capturing the full story.
    """
    display_name = "MRS Full Story"

class SMMSanity(Toggle):
    """
    Adds multiple checks to various tasks in Sonic Movie Maker (Foodsanity/Birthsanity).
    """
    display_name = "SMM Sanity"

class AscensionsToGoal(Range):
    """
    The amount of Ascensions needed to goal. This will increase the amount of items and locations in the pool (7 items and 8 locations per ascension).
    """
    display_name = "Ascensions to Goal"
    range_start = 1
    range_end = 100
    default = 1

class JunkPercentage(Range):
    """
    Percentage of non-required Robust Worms to be converted to junk items.
    """
    display_name = "Junk Percentage"
    range_start = 0
    range_end = 100
    default = 50

@dataclass
class SDCOptions(PerGameCommonOptions):
    mrs_full_story: MRSFullStory
    smm_sanity: SMMSanity
    ascensions_to_goal: AscensionsToGoal
    junk_percentage: JunkPercentage