using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(CameraPlus.Config), nameof(CameraPlus.Config.Load))]
    public class ConfigLoadOverride
    {
        public static event Action ConfigLoaded;

        internal static void Postfix()
        {
            ConfigLoaded?.Invoke();
        }
    }
}
