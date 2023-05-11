using Assets.CodeBase.App.Services;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.App.StateMachine
{
    public class LoadSceneState : IParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneService _sceneService;  
        private readonly GameObjectsController _gameObjectsController;
        private readonly WaveController _waveController;

        public LoadSceneState(GameStateMachine gameStateMachine, ISceneService sceneService, GameObjectsController gameObjectsController, WaveController waveController)
        {
            _gameStateMachine = gameStateMachine;
            _sceneService = sceneService;         
            _gameObjectsController = gameObjectsController;
            _waveController = waveController;
        }
        public void Enter<T>(T data)
        {
            string sceneName = data as string;
            if (sceneName == null)
                throw new ArgumentException();
            _sceneService.Load(sceneName,OnLoaded);
        }
        public void OnLoaded()
        {
            _gameObjectsController.SetupSceneWithObject();
            _waveController.StartWave();
        }
        public void Exit()
        {
        }
    }
}
