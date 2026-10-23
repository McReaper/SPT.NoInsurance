using System.Reflection;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace NoInsurance.Patches
{
    /// <summary>
    /// In SPT 4.x, MainMenuShowOperation.method_51 builds and shows the matchmaker insurance screen,
    /// then continues to method_52 (the "ready / accept" step). We skip the screen entirely and go
    /// straight to method_52, without touching RaidSettings.RaidMode (which Fika and group logic rely on).
    /// </summary>
    internal class SkipInsuranceScreen : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MainMenuShowOperation), nameof(MainMenuShowOperation.method_51));
        }

        [PatchPrefix]
        private static bool Prefix(MainMenuShowOperation __instance)
        {
            __instance.method_52();
            return false;
        }
    }
}
