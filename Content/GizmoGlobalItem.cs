using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace GizmosGizmos.Content;

public class GizmoGlobalItem: GlobalItem {
  public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
    if (item.type == ItemID.OasisCrate || item.type == ItemID.OasisCrateHard) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.EncumberingStone, 3));
    }
    else if (item.type == ItemID.IronCrate || item.type == ItemID.IronCrateHard) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.MagicMirror, 10));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.ShoeSpikes, 6));
    }
    else if (item.type == ItemID.JungleFishingCrate || item.type == ItemID.JungleFishingCrateHard) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.LivingMahoganyWand, 5));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.LivingMahoganyLeafWand, 5));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.HoneyDispenser, 10));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.BeeMinecart, 10));
    }
    else if (item.type == ItemID.FrozenCrate || item.type == ItemID.FrozenCrateHard) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.IceMachine, 5));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.IceMirror, 8));
    }
    else if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.FloatingIslandFishingCrateHard) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.SkyMill, 8));
    }
    else if (item.type == ItemID.ObsidianLockbox) {
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Meteorite, 2, 12, 24));
      itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.Hellstone, 2, 6, 16));
    }
  }
}
