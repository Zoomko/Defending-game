using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.App.StateMachine
{
    internal class LoadPersistentDataState : INoneParameterizedState
    {
        private const string GameScene = "Game";
        private readonly GameStateMachine _gameStateMachine;
        private readonly PersistentDataService _persistentDataService;

        public LoadPersistentDataState(GameStateMachine gameStateMachine, PersistentDataService persistentDataService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentDataService = persistentDataService;
        }
        public void Enter()
        {
            _persistentDataService.Load();
            _gameStateMachine.Enter<LoadSceneState,string>(GameScene);
        }

        public void Exit()
        {

        }
    }
}
