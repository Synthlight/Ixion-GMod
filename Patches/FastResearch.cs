using System.Reflection;
using BulwarkStudios.Stanford.Common.TechTree;
using HarmonyLib;

namespace GMod.Patches;

// ReSharper disable RedundantAssignment, UnusedMember.Global
[HarmonyPatch]
public class FastResearch {
    [HarmonyTargetMethod]
    public static MethodBase TargetMethod() {
        return typeof(CommandResearchTechnology).GetMethod(nameof(CommandResearchTechnology.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
    }

    [HarmonyPrefix]
    public static bool Prefix(ref float deltaTime) {
        deltaTime = 10f;
        return true;
    }
}