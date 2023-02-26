using System;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner _coroutineRunnerPrefab;
    [SerializeField] private GameBootstrapper _gameBootstrapperPrefab;
    public override void InstallBindings()
    {
        BindDailyBonusService();
        BindTimeConverter();
        BindAssetProvider();
        BindUIFactory();
        BindCoroutineRunner();
        BindGameTimer();
        BindLifeSirvece();
        BindPopUpNavigator();
        BindGameBootstrapper();
    }
    private void BindDailyBonusService()
    {
        Container.Bind<IDailyBonusService>().To<DailyBonusService>().AsSingle().NonLazy();
    }
    private void BindTimeConverter() =>
        Container.Bind<ITimeConverter>().To<TimeConverter>().AsSingle();

    private void BindAssetProvider() =>
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

    private void BindCoroutineRunner()
    {
        CoroutineRunner coroutineRunner = Container.InstantiatePrefabForComponent<CoroutineRunner>(_coroutineRunnerPrefab);
        Container.Bind<ICoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
    }

    private void BindUIFactory() =>
        Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

    private void BindGameTimer() =>
        Container.Bind<IGameTimer>().To<GameTimer>().AsSingle();

    private void BindLifeSirvece() =>
        Container.Bind<ILifeService>().To<LifeService>().AsSingle();

    private void BindPopUpNavigator() =>
        Container.Bind<IPopUpNavigator>().To<PopUpNavigator>().AsSingle();

    private void BindGameBootstrapper()
    {
        GameBootstrapper gameBootstrapper = Container.InstantiatePrefabForComponent<GameBootstrapper>(_gameBootstrapperPrefab);
        Container.Bind<GameBootstrapper>().FromInstance(gameBootstrapper).AsSingle();
    }
}
