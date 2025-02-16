from typing import Union, Optional
from BaseClasses import CollectionState
from .Options import SDCOptions

class SDCLogic:
    player: int

    def __init__(self, player:int, options:SDCOptions):
        self.player = player

    def has_acc_worms(self, worms, acc, state: CollectionState) -> bool:
        # Worms needed for check z is:
        # z=6(x-1)+y
        # where
        # x = account number
        # y = worm number
        return state.has('Robust Worm', self.player, (6*(acc-1)+worms))
    
    def has_acc(self, acc, state: CollectionState) -> bool:
        return state.has('SegaNet Account', self.player, acc)
    
    def has_mms(self, state: CollectionState) -> bool:
        return state.has('Make My Sonic', self.player)
    
    def has_seganet_mms(self, state: CollectionState) -> bool:
        return state.has_all({'SegaNet Adapter', 'Make My Sonic'}, self.player)
    
    def has_full_eo(self, state: CollectionState) -> bool:
        return state.has_all({'SegaNet Adapter','Make My Sonic','Eggman Origin'}, self.player)
    
    def has_mrs(self, state: CollectionState) -> bool:
        return state.has('My Roommate Sonic', self.player)
    
    def has_s1(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Backyard'}, self.player)
    
    def has_s2(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Prom'}, self.player)
    
    def has_s3(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Hotel'}, self.player)
    
    def has_s4(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Feeding'}, self.player)
    
    def has_s5(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Birthing'}, self.player)
    
    def has_s6(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'Crib'}, self.player)
    
    def has_dlc(self, state: CollectionState) -> bool:
        return state.has_all({'Sonic Movie Maker', 'My Roommate Sonic'}, self.player)
    

