using CameraPlusUIPlus.Modules;
using CameraPlusUIPlus.Views;
using HMUI;
using SiraUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRUIControls;
using Zenject;

namespace CameraPlusUIPlus.Installer
{
    public class CameraUIPlusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<CameraPlusUIPlusController>().FromNewComponentOnNewGameObject().AsSingle();
            this.Container.BindInterfacesAndSelfTo<CameraFlowtingViewController.Factory>().AsSingle();
        }
    }
}
