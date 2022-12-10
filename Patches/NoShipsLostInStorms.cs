using System.Reflection;
using BulwarkStudios.Stanford.Common.Weather;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NoShipsLostInStorms1 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandWeather).GetMethod(nameof(CommandWeather.AddSpaceVehicleStateToInside), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandWeather __instance) {
        __instance.spaceVehiclesInside.Clear();
        return false;
    }
}

[HarmonyPatch]
public class NoShipsLostInStorms2 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(WeatherBehaviour).GetMethod(nameof(WeatherBehaviour.IsPointInsidePattern), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref bool __result) {
        __result = false;
        return false;
    }
}

[HarmonyPatch]
public class NoShipsLostInStorms3 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandWeather).GetMethod(nameof(CommandWeather.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandWeather __instance) {
        __instance.spaceVehiclesInside.Clear();
        __instance.RefreshDefaultTickCycleTime();
        return true;
    }
}