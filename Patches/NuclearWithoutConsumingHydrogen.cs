using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NuclearWithoutConsumingHydrogen {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingNuclearPowerPlant).GetMethod(nameof(CommandBuildingNuclearPowerPlant.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandBuildingNuclearPowerPlant __instance, ref float deltaTime) {
        deltaTime = 0f;
        return true;
    }
}