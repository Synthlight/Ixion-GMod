using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class MoreStorage {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(BuildingActionTotalCapacity).GetMethod(nameof(BuildingActionTotalCapacity.GetTotalCapacityStockpile), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPostfix]
    public static void Postfix(ref int __result) {
        __result *= 10;
    }
}