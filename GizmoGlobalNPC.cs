using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using System.Collections.Generic;
using GizmosGizmos.Content.Items;

namespace GizmosGizmos;

class GizmoGlobalNPC: GlobalNPC {
  public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
  {
    switch (npc.type) {
      case NPCID.LunarTowerSolar:
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SolarCube>()));
        break;
      case NPCID.LunarTowerNebula:
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<NebulaCube>()));
        break;
      case NPCID.LunarTowerStardust:
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<StardustCube>()));
        break;
      case NPCID.LunarTowerVortex:
        npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<VortexCube>()));
        break;
      default:
        break;
    }

    List<int> canDropLifeFruits = new List<int> {
      NPCID.MossHornet,
      NPCID.BigMossHornet,
      NPCID.GiantMossHornet,
      NPCID.LittleMossHornet,
      NPCID.AngryTrapper
    };

    if (canDropLifeFruits.Contains(npc.netID)) {
        npcLoot.Add(
            ItemDropRule.ByCondition(
              new Conditions.BeatAnyMechBoss(),
              ItemID.LifeFruit, chanceNumerator: 1, chanceDenominator: 30) // 1 in 30 or 3.33%
            );
    }
  }
}
