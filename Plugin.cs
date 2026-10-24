using BepInEx;
using BepInEx.Logging;
using NoInsurance.Patches;

namespace NoInsurance
{
    [BepInPlugin("com.mcreaper.noinsurance", "No Insurance", "2.0.0")]
    [BepInDependency("com.SPT.core", "4.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;

        private void Awake()
        {
            LogSource = Logger;

            new SkipInsuranceScreen().Enable();

            LogSource.LogInfo("[No Insurance] plugin loaded!");
        }
    }
}
