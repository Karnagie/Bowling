using SettingsEssence;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SettingsInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;
        
        public override void InstallBindings()
        {
            Container.Bind<Settings>().FromInstance(_settings).AsSingle();
        }
    }
}