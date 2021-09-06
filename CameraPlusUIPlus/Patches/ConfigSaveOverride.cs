using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(CameraPlus.Configuration.CameraConfig), nameof(CameraPlus.Configuration.CameraConfig.Save))]
    public class ConfigSaveOverride
    {
        public static event Action<CameraPlus.Configuration.CameraConfig> ConfigSaved;

        internal static void Postfix(CameraPlus.Configuration.CameraConfig __instance)
        {
            // 保存したことはわかるがどのコンフィグなのかは不明なので今のところ使えない。
            ConfigSaved?.Invoke(__instance);
        }
    }
}
