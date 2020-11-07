using CameraPlusUIPlus.Modules;
using SiraUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace CameraPlusUIPlus.Installer
{
    public class CameraUIPlusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<CameraPlusUIPlusController>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}
