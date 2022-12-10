using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;

namespace GMod {
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin {
        private const  string          UUID = "com.gmod";
        private static ManualLogSource logSource;

        public override void Load() {
            logSource = Log;

            LogWrite(LogLevel.Info, "GMod loaded.");

            var harmony = new Harmony(UUID);
            harmony.PatchAll();

            LogWrite(LogLevel.Info, "GMod patched.");

            foreach (var patchedMethod in harmony.GetPatchedMethods()) {
                LogWrite(LogLevel.Info, $"Patched: {patchedMethod.DeclaringType?.FullName}:{patchedMethod}");
            }
        }

        public static void LogWrite(LogLevel level, string msg) {
            logSource.Log(level, msg);
        }
    }
}