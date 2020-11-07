using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using CameraPlus;
using CameraPlusUIPlus.Patches;
using CameraPlusUIPlus.Views;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public IEnumerable<FloatingScreen> Screens { get; private set; }

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
            this.Screens = new FloatingScreen[0];
        }
        
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
        }
        #endregion

        #region Zenject method
        public void Initialize()
        {
            ReloadCameraOverride.ReloadCameraEvent -= this.ReloadCameraOverride_ReloadCameraEvent;
            ReloadCameraOverride.ReloadCameraEvent += this.ReloadCameraOverride_ReloadCameraEvent;
        }

        private void ReloadCameraOverride_ReloadCameraEvent(ConcurrentDictionary<string, CameraPlusInstance> obj)
        {
            this.CreateFlowtingScreens(obj);
        }
        #endregion

        void CreateFlowtingScreens(ConcurrentDictionary<string, CameraPlusInstance> dic)
        {
            Logger.Debug("Start create screen");
            try {
                var screens = new List<FloatingScreen>();

                foreach (var screen in this.Screens) {
                    Destroy(screen);
                }

                foreach (var item in dic.Where(x => x.Value.Instance.Config.showThirdPersonCamera)) {
                    var screen = FloatingScreen.CreateFloatingScreen(new Vector2(80f, 100f), false, new Vector3(0.9f, 0, 0), Quaternion.Euler(0f, 180f, 0f));
                    var mainView = BeatSaberUI.CreateViewController<CameraFlowtingViewController>();
                    mainView.SetCurrentInstance(item.Key, item.Value);
                    mainView.ProfileSeverClickEnvet += this.MainView_ProfileSeverClickEnvet;
                    screen.SetRootViewController(mainView, HMUI.ViewController.AnimationType.None);
                    screen.gameObject.transform.SetParent(item.Value.Instance.gameObject.transform);
                    screens.Add(screen);
                }

                this.Screens = screens.AsEnumerable();
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }

        private void MainView_ProfileSeverClickEnvet(CameraFlowtingViewController arg1, KeyValuePair<string, CameraPlusInstance> arg2)
        {
            throw new NotImplementedException();
        }
    }
}
