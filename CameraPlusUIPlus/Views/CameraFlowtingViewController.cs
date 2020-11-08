using System;
using System.Collections.Generic;
using System.Linq;

using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using CameraPlus;
using HMUI;
using IPA.Utilities;
using UnityEngine;
using VRUIControls;
using Zenject;

namespace CameraPlusUIPlus.Views
{
    [HotReload]
    public class CameraFlowtingViewController : BSMLAutomaticViewController
    {
        // For this method of setting the ResourceName, this class must be the first class in the file.
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        public event Action<CameraFlowtingViewController, KeyValuePair<string, CameraPlusInstance>> ProfileSeverClickEnvet;

        KeyValuePair<string, CameraPlusInstance> _currentInstance;

        [UIAction("#post-parse")]
        void PostPaese()
        {
            
        }

        [UIComponent("main-modal")]
        ModalView _mainModal;
        [UIComponent("profile-modal")]
        ModalView _profileModal;

        [UIAction("open-main-modal")]
        void OpenMain()
        {
            try {
                Logger.Debug($"modal is null? : {_mainModal == null}");
                this._mainModal.transform.SetParent(this.rectTransform);
                Logger.Debug($"parent is null? : {this._mainModal.transform.parent == null}");
                
                this._mainModal.Show(true);
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }


        [UIAction("open-profile-modal")]
        void OpenProfile()
        {
            try {
                Logger.Debug($"modal is null? : {_profileModal == null}");
                this._profileModal.transform.SetParent(this.rectTransform);
                this._profileModal.Show(true);
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }


        public void SetCurrentInstance(string fileName, CameraPlusInstance instance)
        {
            this._currentInstance = new KeyValuePair<string, CameraPlusInstance>(fileName, instance);
            Logger.Debug(this._currentInstance.Key);
        }

        public class Factory : IFactory<CameraFlowtingViewController>
        {
            [Inject]
            DiContainer Container;

            public CameraFlowtingViewController Create()
            {
                return BeatSaberUI.CreateViewController<CameraFlowtingViewController>();
            }
        }
    }
}
