using System;
using System.Reflection;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FastScienceAccrual {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingScienceLab).GetMethod(nameof(CommandBuildingScienceLab.GetCooldown), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPostfix]
    public static void Postfix(ref CommandBuildingScienceLab __instance) {
        try {
            Game.Common.player.State.Science = 999;
        } catch (Exception) {
            // ignored
        }
    }
}