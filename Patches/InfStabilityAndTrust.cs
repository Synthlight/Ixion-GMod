using System.Reflection;
using BulwarkStudios.Stanford.Torus.Sectors;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class InfStabilityAndTrust {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(TorusSectorStateStability).GetMethod(nameof(TorusSectorStateStability.RecalculateStability), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref int __result) {
        __result = 5;
        return false;
    }
}