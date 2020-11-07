using CameraPlus;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(CameraUtilities), nameof(CameraUtilities.ReloadCameras))]
    public class ReloadCameraOverride
    {
        public static event Action<ConcurrentDictionary<string, CameraPlusInstance>> ReloadCameraEvent;


        internal static void Postfix()
        {
            ReloadCameraEvent?.Invoke(CameraPlus.Plugin.Instance.Cameras);
        }
    }
}
