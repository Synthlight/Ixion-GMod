using System;
using System.Reflection;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FasterMiningShips {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(SpaceVehicleData).GetMethod(nameof(SpaceVehicleData.GetSpeed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPostfix]
    public static void Postfix(ref SpaceVehicleData __instance, ref float __result) {
        var ourCat            = __instance.VehicleCategory.categoryName;
        var miningShipBaseCat = Game.Data?.ships?.miningShip?.VehicleCategory?.categoryName;
        if (miningShipBaseCat != null && ourCat == miningShipBaseCat) {
            //Debug.Log($"Ship cat: {ourCat}, speed: {__result} (Miner)");
            __result = Math.Max(0.05f, __result);
        }
    }
}