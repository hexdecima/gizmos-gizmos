using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace GizmosGizmos.Content.Items;

public class NatureCharm: ModItem {
  public override void SetStaticDefaults()
  {
    Item.ResearchUnlockCount = 3;
    ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
    NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
  }
    
  public override void SetDefaults()
  {
    Item.maxStack = Item.CommonMaxStack;
    Item.consumable = true;
    Item.width = 24;
    Item.height = 24;
    Item.rare = ItemRarityID.Pink;
    Item.useAnimation = 30;
    Item.useTime = 30;
    Item.useStyle = ItemUseStyleID.HoldUp;
  }
  public override void AddRecipes()
  {
    CreateRecipe()
      .AddIngredient(ItemID.SoulofMight, 6)
      .AddIngredient(ItemID.SoulofFright, 6)
      .AddIngredient(ItemID.SoulofSight, 6)
      .AddIngredient(ItemID.ChlorophyteBar, 4)
      .AddTile(TileID.MythrilAnvil)
      .Register();
  }

  public override bool CanUseItem(Player player)
  {
    return !NPC.AnyNPCs(NPCID.Plantera) && Main.LocalPlayer.ZoneJungle;
  }
  
  public override bool? UseItem(Player player) {
    if (player.whoAmI == Main.myPlayer) {
      SoundEngine.PlaySound(SoundID.Roar, player.position);

      if (Main.netMode != NetmodeID.MultiplayerClient) {
        NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
      } else {
        NetMessage.SendData(
            MessageID.SpawnBossUseLicenseStartEvent,
            number: player.whoAmI,
            number2: NPCID.Plantera
          );
      }
    }
    return true;
  }
}
