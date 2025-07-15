using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace GizmosGizmos;

public class GizmoPlayer: ModPlayer {
  public override void CatchFish(
      FishingAttempt attempt, 
      ref int itemDrop,
      ref int npcSpawn,
      ref AdvancedPopupRequest sonar,
      ref Vector2 sonarPosition
      ) {
    // Underground or Caverns Jungle as long as Plantera is down.
    bool canFishLifeFruit = Main.LocalPlayer.ZoneJungle
      && (NPC.downedMechBossAny)
      && (Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneDirtLayerHeight);

    if (canFishLifeFruit) {
      if (attempt.uncommon && (Main.rand.Next(0, 3) == 0)) {
        itemDrop = ItemID.LifeFruit;
        sonar.Color = Colors.RarityLime;
      }
    }
  }
}
