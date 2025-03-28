using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : EndOfFrameExitState
    {
        private HomeScreenFeature _homeScreenFeature;

        private readonly GameContext _gameContext;
        private readonly ISystemFactory _systemFactory;
        private readonly IStorageUIService _storageUIService;

        public HomeScreenState(GameContext gameContext,
            ISystemFactory systemFactory,
            IStorageUIService storageUIService)
        {
            _gameContext = gameContext;
            _systemFactory = systemFactory;
            _storageUIService = storageUIService;
        }
        
        public override void Enter()
        {
            _homeScreenFeature = _systemFactory.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        {
            _storageUIService.Cleanup();
            
            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();
            
            DestructEntities();
            
            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
        }
        
        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}