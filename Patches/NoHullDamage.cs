using System.Reflection;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Torus.Structure;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NoHullDamage {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandHullConsumption).GetMethod(nameof(CommandHullConsumption.Tick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix() {
        Game.Torus.torus.State.HullIntegrity = Game.Torus.torus.State.MaxHullIntegrity;
        return true;
    }
}