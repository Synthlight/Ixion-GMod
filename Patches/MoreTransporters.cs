using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;

namespace GMod.Patches;

// Doesn't actually work for some reason. Needs further investigation.

// ReSharper disable RedundantAssignment, UnusedMember.Global
//[HarmonyPatch]
public class MoreTransporters {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(BuildingActionBehaviourStockpile).GetMethod(nameof(BuildingActionBehaviourStockpile.GetNbTransporters), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref int __result) {
        __result = 20;
        return false;
    }
}