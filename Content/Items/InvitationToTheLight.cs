using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace GizmosGizmos.Content.Items;

public class InvitationToTheLight: ModItem {
  public override void SetStaticDefaults()
  {
    Item.ResearchUnlockCount = 3;
    ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
    NPCID.Sets.MPAllowedEnemies[NPCID.HallowBoss] = true;
  }
    
  public override void SetDefaults()
  {
    Item.maxStack = Item.CommonMaxStack;
    Item.consumable = true;
    Item.width = 24;
    Item.height = 24;
    Item.rare = ItemRarityID.Orange;
    Item.useAnimation = 30;
    Item.useTime = 30;
    Item.useStyle = ItemUseStyleID.HoldUp;
  }
  public override bool CanUseItem(Player player)
  {
     return !NPC.AnyNPCs(NPCID.HallowBoss) && NPC.downedPlantBoss;
  }
  public override bool? UseItem(Player player) {
    if (player.whoAmI == Main.myPlayer) {
      SoundEngine.PlaySound(SoundID.Roar, player.position);

      if (Main.netMode != NetmodeID.MultiplayerClient) {
        NPC.SpawnOnPlayer(player.whoAmI, NPCID.HallowBoss);
      } else {
        NetMessage.SendData(
            MessageID.SpawnBossUseLicenseStartEvent,
            number: player.whoAmI,
            number2: NPCID.HallowBoss
          );
      }
    }
    return true;
  }
}
