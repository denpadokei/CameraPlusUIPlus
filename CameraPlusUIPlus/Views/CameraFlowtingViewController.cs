using System;
using System.Collections.Generic;
using System.Linq;

using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using CameraPlus;

namespace CameraPlusUIPlus.Views
{
    [HotReload]
    public class CameraFlowtingViewController : BSMLAutomaticViewController
    {
        // For this method of setting the ResourceName, this class must be the first class in the file.
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        public event Action<CameraFlowtingViewController, KeyValuePair<string, CameraPlusInstance>> ProfileSeverClickEnvet;

        KeyValuePair<string, CameraPlusInstance> _currentInstance;

        public void SetCurrentInstance(string fileName, CameraPlusInstance instance)
        {
            this._currentInstance = new KeyValuePair<string, CameraPlusInstance>(fileName, instance);
        }

        [UIAction("profile-saver-click")]
        void ProfileSaverClock()
        {
            this.ProfileSeverClickEnvet?.Invoke(this, this._currentInstance);
        }
    }
}
