using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace GizmosGizmos.Content.Items;

abstract class PillarCube: ModItem {
  abstract public short FragmentID { get; }

  public override void SetStaticDefaults()
  {
    ItemID.Sets.BossBag[Type] = true;
    // Prevents dev sets from dropping.
    ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
  }

  public override void SetDefaults() {
    Item.maxStack = Item.CommonMaxStack;
    Item.consumable = true;
    Item.height = 32;
    Item.width = 32;
    Item.rare = ItemRarityID.Cyan;
    Item.expert = true;
  }

  public override bool CanRightClick() => true;

  public override void ModifyItemLoot(ItemLoot itemLoot)
  {
    itemLoot.Add(ItemDropRule.Common(this.FragmentID, 1, 16, 22));
  }
}
