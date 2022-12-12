using System.Reflection;
using BulwarkStudios.Stanford.Torus.Structure;
using HarmonyLib;

namespace GMod.Patches;

// Untested.

// ReSharper disable RedundantAssignment, UnusedMember.Global
//[HarmonyPatch]
public class NoMaxHullLost {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(TorusState).GetMethod(nameof(TorusState.AddMaxHullIntegrityModifier), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref float modifier) {
        modifier = 0;
        return true;
    }
}