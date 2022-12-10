using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NoAccidents1 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandSectorAccidentManagement).GetMethod(nameof(CommandSectorAccidentManagement.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref CommandSectorAccidentManagement __instance) {
        __instance.ResetAccidentGauge();
        return true;
    }
}

[HarmonyPatch]
public class NoAccidents2 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandSectorAccidentManagement).GetMethod(nameof(CommandSectorAccidentManagement.GetTremorChance), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref float __result) {
        __result = 0f;
        return false;
    }
}