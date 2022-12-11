using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class MoreTransporters {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingStockpile).GetMethod(nameof(CommandBuildingStockpile.ManageNormalTransporters), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandBuildingStockpile __instance) {
        __instance.nbTransporter = 0;
        return true;
    }
}