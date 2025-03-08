using Code.Gameplay.StaticData;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class HomeHUD : MonoBehaviour
    {
        public Button StartBattleButton;

        private IGameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _stateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
        }

        private void EnterBattleLoadingState() =>
            _stateMachine.Enter<LoadingBattleState, string>(_staticDataService.GameConfig.GameScene);
    }
}