using Assets.CodeBase.App.Services;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.App.StateMachine
{
    public class SpawnObjectsState : INoneParameterizedState
    {
        private readonly GameStateMachine _gameStateMachine;          
        private readonly WaveController _waveController;
        private readonly PersistentDataService _persistentDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly ICrystalFactory _crystalFactory;
        private readonly IEnemyFactory _enemyFactory;

        public SpawnObjectsState(GameStateMachine gameStateMachine,
                                 WaveController waveController,
                                 PersistentDataService persistentDataService,
                                 IPlayerFactory playerFactory,
                                 ICrystalFactory crystalFactory,
                                 IEnemyFactory enemyFactory)
        {
            _gameStateMachine = gameStateMachine;          
            _waveController = waveController;
            _persistentDataService = persistentDataService;
            _playerFactory = playerFactory;
            _crystalFactory = crystalFactory;
            _enemyFactory = enemyFactory;
        }

        public void Enter()
        {
            _enemyFactory.InitializePool();

            PlayerSpawner playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
            EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();
            CrystalSpawner crystalSpawner = GameObject.FindObjectOfType<CrystalSpawner>();

            var player = _playerFactory.Create();
            playerSpawner.Spawn(player);

            var crystal = _crystalFactory.Create();
            crystalSpawner.Spawn(crystal);

            _waveController.SetSpawners(enemySpawners);
            _waveController.StartWave();
        }

        public void Exit()
        {
            
        }
    }
}
