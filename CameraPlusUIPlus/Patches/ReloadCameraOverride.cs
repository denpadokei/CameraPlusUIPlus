using CameraPlus;
using CameraPlus.Behaviours;
using CameraPlus.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CameraPlusUIPlus.Patches
{
    [HarmonyLib.HarmonyPatch("CameraPlus.Behaviours.CameraPreviewQuad, CameraPlus, Version=6.0.4.0, Culture=neutral, PublicKeyToken=null", "Init")]
    public class ReloadCameraOverride
    {
        public static event Action<GameObject> AwakedCamera;


        internal static void Postfix(ref GameObject ____cameraCube)
        {
            AwakedCamera?.Invoke(____cameraCube);
        }
    }
}
