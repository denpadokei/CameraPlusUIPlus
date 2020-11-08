using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(CameraPlus.Config), nameof(CameraPlus.Config.Save))]
    public class ConfigSaveOverride
    {
        public static event Action ConfigSaved;

        internal static void Postfix()
        {
            ConfigSaved?.Invoke();
        }
    }
}
