using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(CameraPlus.Configuration.CameraConfig), nameof(CameraPlus.Configuration.CameraConfig.Load))]
    public class ConfigLoadOverride
    {
        public static event Action<CameraPlus.Configuration.CameraConfig> ConfigLoaded;

        internal static void Postfix(CameraPlus.Configuration.CameraConfig __instance)
        {
            ConfigLoaded?.Invoke(__instance);
        }
    }
}
