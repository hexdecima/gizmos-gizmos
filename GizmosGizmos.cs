using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace GizmosGizmos; 

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

    Recipe.Create(ItemID.LifeCrystal)
      .AddIngredient(ItemID.LifeFruit)
      .AddCondition(Condition.InGraveyard)
      .Register();
  }
}
