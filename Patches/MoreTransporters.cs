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

// Should work, but just seems to stop sector transfers altogether.

//[HarmonyPatch]
public class MoreSpecialTransporters {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingStockpile).GetMethod(nameof(CommandBuildingStockpile.ManageSpecialTransporters), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandBuildingStockpile __instance) {
        //var allowedResource = __instance.building.Value.State.stockpile.AllowedResource;
        //__instance.SpecialTransporterEnded(new(allowedResource, 0, __instance.building.Value, __instance.building.Cast<BuildingInstance>().GetSector()));

        //var allowedResource = __instance.building.Value.State.stockpile.AllowedResource;
        //__instance.sector.Value.State.availableSpecialTransporters[allowedResource] = 50;

        //var allResources                 = Game.Data.resourceList.allResources;
        //var availableSpecialTransporters = __instance.sector.Value.State.availableSpecialTransporters;
        //// ReSharper disable once ForCanBeConvertedToForeach
        //for (var i = 0; i < allResources.Count; i++) {
        //    var resource = allResources[i];
        //    if (!resource.IsStorable) continue;
        //    availableSpecialTransporters[resource] = 50;
        //}
        return true;
    }
}