using System.Reflection;
using BulwarkStudios.Stanford.Common.Decrees;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NoPolicyCooldown {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(TorusSectorStateDecrees).GetProperty(nameof(TorusSectorStateDecrees.DecreeCooldownRemaining), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)?.GetSetMethod();
    }

    [HarmonyPrefix]
    public static bool Prefix(ref float value) {
        value = 0f;
        return true;
    }
}