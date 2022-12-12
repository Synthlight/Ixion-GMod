using System.Reflection;
using BulwarkStudios.Stanford.Common.TechTree;
using BulwarkStudios.Stanford.Common.UI;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class NoTierNeededForResearchUpgrade1 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(TechnologyData).GetProperty(nameof(TechnologyData.IsLockByTier), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)?.GetGetMethod();
    }

    [HarmonyPrefix]
    public static bool Prefix(ref TechnologyData __instance) {
        __instance.requiredTier = null;
        return true;
    }
}

[HarmonyPatch]
public class NoTierNeededForResearchUpgrade2 {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(UITechnologyInfos).GetMethod(nameof(UITechnologyInfos.UpdateButtons), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref UITechnologyInfos __instance) {
        __instance.technologyData.requiredTier = null;
        return true;
    }
}