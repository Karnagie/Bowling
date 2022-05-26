using BreakableObjects.BallEssence;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BallSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private BallSpawner _spawner;

        public override void InstallBindings()
        {
            Container.Bind<BallSpawner>().FromInstance(_spawner).AsSingle();
        }
    }
}