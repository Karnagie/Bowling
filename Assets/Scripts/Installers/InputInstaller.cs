using Core.InputEssence;
using SettingsEssence;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        [Inject] private Settings _settings;
        
        public override void InstallBindings()
        {
            IInput input;
#if UNITY_EDITOR
            input = new MouseInput(_settings.Sensitivity);
#else
            //todo mobile input
#endif
            Container.Bind<IInput>().FromInstance(input).AsSingle();
        }
    }
}