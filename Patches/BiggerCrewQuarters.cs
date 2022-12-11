using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class BiggerCrewQuarters {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(BuildingActionBehaviourQuarter).GetMethod(nameof(BuildingActionBehaviourQuarter.GetMaxCitizen), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Postfix(ref BuildingActionBehaviourQuarter __instance, ref int __result) {
        __result = __instance.citizenCapacity * 5;
        return false;
    }
}