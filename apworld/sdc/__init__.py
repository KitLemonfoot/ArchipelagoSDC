from typing import Dict, Any
from worlds.AutoWorld import World
from BaseClasses import Region, Location, Entrance, Item, ItemClassification
from .Options import SDCOptions
from .Items import base_id, item_list
from .Locations import get_location_data
from .Regions import Regions
import math

class SDCItem(Item):
    game = "Sonic Dreams Collection"

class SDCLocation(Location):
    game = "Sonic Dreams Collection"

class SDCWorld(World):
    """
    In 2013 hacker supergroup “Arcane Kid$” acquired a SEGA DREAMCAST developer kit from ebay.com.
    Deep in the filescape they unearthed a note from the director of MJSTUDIO,
    a “message in a bottle” detailing the work of SEGA's top secret studio which was re-invisioning the future of video gaming.
    The Arcane Kid$ salvaged FOUR playable prototypes, some concept art, and countless top-secret SEGA files.
    “SEGA squandered MJSTUDIO's gift to the world… and dissed Sonic fans globally… by burying these games” Arcane Kid$ spokesperson Jo says.
    “It's time to set them free.”
    """

    game = "Sonic Dreams Collection"

    options_dataclass = SDCOptions
    options: SDCOptions

    item_name_to_id = {item.name: (base_id + index) for index, item in enumerate(item_list)}
    location_name_to_id = {loc.name: (base_id + index) for index, loc in enumerate(get_location_data(-1, None))}


    def __init__(self, multiworld, player):
        super(SDCWorld, self).__init__(multiworld, player)
        self.start_location: str = "Another Little Game Slave..."
        startGames = ["Make My Sonic", "My Roommate Sonic"]
        self.startGame: str = self.random.choice(startGames)
        self.game_id_to_long: Dict[str, int] = {}
        self.doingJunk=False
        

    def create_item(self, name: str) -> SDCItem:
        item_id: int = self.item_name_to_id[name]
        id = item_id - base_id
        classification = item_list[id].classification
        if(self.doingJunk):
            classification = ItemClassification.filler
        return SDCItem(name, classification, item_id, self.player)
    

    def create_regions(self):

        player = self.player
        multiworld = self.multiworld

        #Region handler
        menu = Region("Menu", player, multiworld)
        for r in Regions.all_regions:
            multiworld.regions += [Region(r.full_name, player, multiworld)]
            menu.add_exits({r.full_name})
        multiworld.regions.append(menu)

        #Handle locations.
        #This is a messy way to do this, but given how dynamic this APworld has to be I don't have a choice.
        for loc in get_location_data(player, self.options):
            id = self.location_name_to_id[loc.name]
            self.game_id_to_long[loc.game_id] = id
            region: Region = self.get_region(loc.region.full_name)
            location = SDCLocation(player, loc.name, id, region)
            if loc.logic:
                location.access_rule = loc.logic
            region.locations.append(location)

        #Handle goal.
        victory: Location = self.get_location(f"Eggman Origin - Account {self.options.ascensions_to_goal.value} Ascension")
        victory.place_locked_item(self.create_item("Final Ascension"))
        multiworld.completion_condition[player] = lambda state: state.has("Final Ascension", player)
   

    def create_items(self):
        pool=[]
        player = self.player
        multiworld = self.multiworld

        #Place the first game.
        first_loc = multiworld.get_location(self.start_location, player)
        first_loc.place_locked_item(self.create_item(self.startGame))

        #Handle static items.
        for item in item_list:
            if(item.name==self.startGame or item.name=="Final Ascension"):
                continue
            pool.append(self.create_item(item.name))

        #Handle Robust Worms and SegaNet accounts.
        totalProgWorms = self.options.ascensions_to_goal.value*6
        for _ in range(totalProgWorms):
            pool.append(self.create_item("Robust Worm"))
        for _ in range(self.options.ascensions_to_goal.value-1):
            pool.append(self.create_item("SegaNet Account"))

        #Handle junk items.
        self.doingJunk = True
        junk = len(self.multiworld.get_unfilled_locations(self.player)) - len(pool)
        totalJunkWorms = math.floor(junk*(self.options.junk_percentage / 100.0))
        junk = junk-totalJunkWorms
        for _ in range(totalJunkWorms):
            pool.append(self.create_item("Robust Worm"))
        for _ in range(junk):
            pool.append(self.create_item("Nothing"))

        self.multiworld.itempool += pool

    def fill_slot_data(self) -> Dict[str, Any]:
        slot_data: Dict[str, Any] = {
            "version": "0.1.1",
            "locations": self.game_id_to_long,
            "AscensionsToGoal": self.options.ascensions_to_goal.value
        }
        return slot_data