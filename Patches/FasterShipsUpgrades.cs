using System.Reflection;
using BulwarkStudios.Stanford.Core.Instances.Commands;
using BulwarkStudios.Stanford.Core.ObjectDataPattern;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Commands;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FasterCargoShipUpgrade {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandStorableTransferProcessTimeDependent).GetMethod(nameof(CommandStorableTransferProcessTimeDependent.ResourceTransfered), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandStorableTransferProcessTimeDependent __instance) {
        var ship = __instance.spaceVehicle.Cast<ObjectInstance<SpaceVehicleData, SpaceVehicleState>>();
        ship.State.Exp += ship.Data.GetExpRequired(ship.State.Level + 1);
        return true;
    }
}

[HarmonyPatch]
public class FasterMineShipUpgrade {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandMiningShip).GetMethod(nameof(CommandMiningShip.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandMiningShip __instance) {
        var ship = __instance.spaceVehicle.Cast<ObjectInstance<SpaceVehicleData, SpaceVehicleState>>();
        ship.State.Exp += ship.Data.GetExpRequired(ship.State.Level + 1);
        return true;
    }
}

[HarmonyPatch]
public class FasterScienceShipUpgrade {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandScienceShip).GetMethod(nameof(CommandScienceShip.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandScienceShip __instance) {
        var ship = __instance.spaceVehicle.Cast<ObjectInstance<SpaceVehicleData, SpaceVehicleState>>();
        ship.State.Exp += ship.Data.GetExpRequired(ship.State.Level + 1);
        return true;
    }
}