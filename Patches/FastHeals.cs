using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FastHeals {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandBuildingMedical).GetMethod(nameof(CommandBuildingMedical.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref float deltaTime) {
        deltaTime *= 15;
        return true;
    }
}