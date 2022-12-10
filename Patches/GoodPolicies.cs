using System;
using System.Reflection;
using BulwarkStudios.Stanford.Common.Decrees;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class GoodPolicies {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(DecreeState).GetMethod(nameof(DecreeState.GetStabilityConsequence), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref DecreeState __instance) {
        __instance.data.options[(Index) __instance.selectedOption].stabilityConsequence = 5;
        return true;
    }
}