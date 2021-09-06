using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using CameraPlus;
using CameraPlus.Behaviours;
using CameraPlusUIPlus.Patches;
using CameraPlusUIPlus.Views;
using IPA.Utilities;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CameraPlusUIPlus.Modules
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class CameraPlusUIPlusController : MonoBehaviour, IInitializable
    {
        public ConcurrentDictionary<string, FloatingScreen> Screens { get; } = new ConcurrentDictionary<string, FloatingScreen>();

        [Inject]
        IFactory<CameraFlowtingViewController> factory;
        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            Plugin.Log?.Debug($"{name}: Awake()");
        }
        
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            ReloadCameraOverride.AwakedCamera -= this.ReloadCameraOverride_ReloadCameraEvent;
            this.DeleteAllScreen();
        }
        #endregion

        #region Zenject method
        public void Initialize()
        {
            ReloadCameraOverride.AwakedCamera -= this.ReloadCameraOverride_ReloadCameraEvent;
            ReloadCameraOverride.AwakedCamera += this.ReloadCameraOverride_ReloadCameraEvent;
        }

        private void ReloadCameraOverride_ReloadCameraEvent(GameObject obj)
        {
            this.CreateFlowtingScreens(obj);
        }
        #endregion

        void DeleteAllScreen()
        {
            foreach (var screen in this.Screens.Values) {
                screen.gameObject.SetActive(false);
                Destroy(screen.gameObject);
            }

            this.Screens.Clear();
        }

        void CreateFlowtingScreens(GameObject obj)
        {
            Logger.Debug("Start create screen");
            try {
                var cameraCube = obj;
                var cameraPosision = cameraCube.transform.position;
                var cameraRotation = cameraCube.transform.rotation;
                Logger.Debug($"{cameraPosision}");
                var screen = FloatingScreen.CreateFloatingScreen(new Vector2(80f, 100f), false, new Vector3(cameraPosision.x + 0.9f, cameraPosision.y, cameraPosision.z), new Quaternion(cameraRotation.x, cameraRotation.y - 180f, -cameraRotation.z, cameraRotation.w));
                var mainView = this.factory.Create();
                //mainView.SetCurrentInstance(item.Key, item.Value);
                screen.SetRootViewController(mainView, HMUI.ViewController.AnimationType.None);
                screen.gameObject.transform.SetParent(cameraCube.transform);
                //this.Screens.AddOrUpdate(item.Key, screen, (k, v) => screen);
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }
    }
}
