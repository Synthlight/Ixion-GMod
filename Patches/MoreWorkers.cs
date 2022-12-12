using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// Should work in theory, but does nothing.

// ReSharper disable RedundantAssignment, UnusedMember.Global
//[HarmonyPatch]
public class MoreWorkers {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingWorkshop).GetMethod(nameof(CommandBuildingWorkshop.SpawnWorker), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandBuildingWorkshop __instance) {
        __instance.nbTransporter = 0;
        return true;
    }
}