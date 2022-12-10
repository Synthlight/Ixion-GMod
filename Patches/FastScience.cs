using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FastScience {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingScienceLab).GetMethod(nameof(CommandBuildingScienceLab.GetCooldown), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPostfix]
    public static void Postfix(ref float __result) {
        if (__result > 0) __result /= 10;
    }
}