using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace NoDoubleTapSprint;

public class NoDoubleTapSprint : ResoniteMod {
    public override string Name => "NoDoubleTapSprint";
    public override string Author => "SemmieDev";
    public override string Version => "1.0.0";
    public override string Link => "https://github.com/SemmieDev/NoDoubleTapSprint";

    public override void OnEngineInit() {
        new Harmony("semmiedev.NoDoubleTapSprint").PatchAll();
    }

    [HarmonyPatch(typeof(KeyboardAndMouseBindingGenerator), "GenerateScreenDirection")]
    internal class KeyboardAndMouseBindingGenerator_GenerateScreenDirection_Patch {

        [HarmonyPostfix]
        private static void DisableDoubleTapSprint(ref ScreenLocomotionDirection __result) {
            __result.Fast = InputNode.Key(Key.Shift);
        }
    }
}