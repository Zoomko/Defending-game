using Assets.CodeBase.App;
using Assets.CodeBase.App.Services;
using Assets.CodeBase.App.StateMachine;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI;
using UnityEngine;
using Zenject;

public class ProjectContext : MonoInstaller
{
    public override void InstallBindings()
    {
        RegisterFactories();
        Container.Bind<ILoadSaveDataFormat>().To<JsonDataService>().AsSingle();
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        Container.Bind<ISceneService>().To<SceneService>().AsSingle();
        Container.Bind<WaveController>().AsSingle();
        Container.Bind<InputService>().AsSingle();
        Container.Bind<RaycastService>().AsSingle();
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<PersistentDataService>().AsSingle();
        Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<SaveLoadController>().AsSingle();
        Container.Bind<UIHUDController>().AsSingle();
    }

    private void RegisterFactories()
    {
        Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        Container.Bind<IBulletFactory>().To<BulletFactory>().AsSingle();
        Container.Bind<ICrystalFactory>().To<CrystalFactory>().AsSingle();
        Container.Bind<IHUDFactory>().To<HUDFactory>().AsSingle();
    }
}
