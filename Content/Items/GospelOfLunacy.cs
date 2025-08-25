using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using System.Collections.Generic;

namespace GizmosGizmos.Content.Items;

public class GospelOfLunacy: ModItem {
  public override void SetStaticDefaults()
  {
    Item.ResearchUnlockCount = 3;
    ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
    NPCID.Sets.MPAllowedEnemies[NPCID.CultistBoss] = true;
  }
    
  public override void SetDefaults()
  {
    Item.maxStack = Item.CommonMaxStack;
    Item.consumable = true;
    Item.width = 24;
    Item.height = 24;
    Item.rare = ItemRarityID.Red;
    Item.useAnimation = 30;
    Item.useTime = 30;
    Item.useStyle = ItemUseStyleID.HoldUp;
  }
  public override void AddRecipes()
  {
    CreateRecipe()
      .AddIngredient(ItemID.SpellTome)
      .AddIngredient(ItemID.HallowedBar, 2)
      .AddIngredient(ItemID.LunarTabletFragment, 4)
      .AddIngredient(ItemID.SoulofNight, 12)
      .AddTile(412)
      .Register();
  }

  public override bool CanUseItem(Player player)
  {
    List<short> pillarIds = new()
      { NPCID.LunarTowerSolar,
        NPCID.LunarTowerNebula,
        NPCID.LunarTowerVortex,
        NPCID.LunarTowerStardust
      };

     return pillarIds.TrueForAll(id => !NPC.AnyNPCs(id)) && !NPC.AnyNPCs(NPCID.CultistBoss);
  }
  public override bool? UseItem(Player player) {
    if (player.whoAmI == Main.myPlayer) {
      SoundEngine.PlaySound(SoundID.Roar, player.position);

      if (Main.netMode != NetmodeID.MultiplayerClient) {
        NPC.SpawnOnPlayer(player.whoAmI, NPCID.CultistBoss);
      } else {
        NetMessage.SendData(
            MessageID.SpawnBossUseLicenseStartEvent,
            number: player.whoAmI,
            number2: NPCID.CultistBoss
          );
      }
    }
    return true;
  }
}
