using System.Reflection;
using BulwarkStudios.Stanford.Common.Specialization;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class MaxSectorSpecFromOnePoint {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(SpecializationState).GetMethod(nameof(SpecializationState.CalculateHighestTierUnlocked), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref SpecializationState __instance) {
        if (__instance.score > 0) __instance.score = 10000;
        return true;
    }
}