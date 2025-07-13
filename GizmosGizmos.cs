using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using System.Collections.Generic;

namespace GizmosGizmos
{
	public class GizmosGizmos: Mod
	{
    public override void AddRecipes() {
      List<(short, short)> biomePairs = new List<(short, short)> {
        (ItemID.CrimsonKey, ItemID.VampireKnives),
        (ItemID.HallowedKey, ItemID.RainbowGun),
        (ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor),
        (ItemID.JungleKey, ItemID.PiranhaGun),
        (ItemID.DungeonDesertKey, ItemID.StormTigerStaff),
        (ItemID.FrozenKey, ItemID.StaffoftheFrostHydra)
        };

      foreach ((short keyId, short weaponId) in biomePairs) {
        Recipe.Create(weaponId)
          .AddIngredient(keyId)
          .AddIngredient(ItemID.TempleKey)
          .AddIngredient(ItemID.Ectoplasm, 6)
          .AddTile(TileID.DemonAltar)
          .Register();
      }
    }
	}
  public class GizmoGlobalItem: GlobalItem {
    public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
      if (item.type == ItemID.OasisCrate || item.type == ItemID.OasisCrateHard) {
        itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.EncumberingStone, 3));
      }
      else if (item.type == ItemID.IronCrate || item.type == ItemID.IronCrateHard) {
        itemLoot.Add(ItemDropRule.NotScalingWithLuck(ItemID.MagicMirror, 10));
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
    }
  }
}
