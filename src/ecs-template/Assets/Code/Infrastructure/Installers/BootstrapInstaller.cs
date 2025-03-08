using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Visuals.Factory;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Meta.UI.GoldHolder.Service;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using RSG;
using Services.SFX;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        [SerializeField] private SoundService _soundService;
        [SerializeField] private MusicService _musicService;
        
        public override void InstallBindings()
        {
            BindMonoServices();
            BindInputService();
            BindInfrastructureServices();
            BindAssetManagementServices();
            BindCommonServices();
            BindSystemFactory();
            BindContexts();
            BindGameplayServices();
            BindCameraProvider();
            BindUIService();
            BindGameplayFactories();
            BindUIFactories();
            BindStateMachine();
            BindStateFactory();
            BindGameStates();
            BindProgressServices();
        }
        
        public void Initialize()
        {
            Promise.UnhandledException += LogPromiseException;
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void BindMonoServices()
        {
            Container.Bind<ISoundService>().FromMethod(() => Container.InstantiatePrefabForComponent<ISoundService>(_soundService)).AsSingle();
            Container.Bind<IMusicService>().FromMethod(() => Container.InstantiatePrefabForComponent<IMusicService>(_musicService)).AsSingle();
        }
        
        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }
        
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }
        
        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
        
        private void BindCommonServices()
        {
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IVibrationService>().To<VibrationService>().AsSingle();
        }

        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }
        
        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }
        
        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
        }
        
        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }
        
        private void BindUIService()
        {
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IStorageUIService>().To<StorageUIService>().AsSingle();
        }
        
        private void BindGameplayFactories()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IVisualFactory>().To<VisualFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
        }

        private void BindUIFactories()
        {
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindStateFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
        }
        
        private void BindProgressServices()
        {
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }
        
        private void LogPromiseException(object sender, ExceptionEventArgs e)
        {
            Debug.LogError(e.Exception);
        }
    }
}