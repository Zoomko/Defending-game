using Assets.CodeBase.Data.PersistentData;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Extentions;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.App
{
    public class GameObjectsController
    {
        private readonly PersistentDataService _persistentDataService;
        private readonly InputService _inputService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly PersistentGameData _persistentData;

        private GameObject _player;
        private Dictionary<EnemyType, GameObject> _enemies;

        public GameObjectsController(IPlayerFactory playerFactory,
                                     IEnemyFactory enemyFactory,
                                     PersistentDataService persistentDataService,
                                     InputService inputService)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _persistentDataService = persistentDataService;
            _inputService = inputService;
            _persistentData = _persistentDataService.PersistentGameData;

            _inputService.SavedProgress += SaveScene;
            _inputService.LoadedProgress += LoadScene;
        }

        public void SetupSceneWithObject()
        {
            SetupPlayer();
        }

        private void SetupPlayer()
        {
            if(_player == null )
            {
                _player = _playerFactory.Create();
            }

            if (_persistentData != null && _persistentData.PlayerData != null)
            {
                var controller = _player.GetComponent<CharacterController>();
                controller.enabled = false;
                _player.transform.position = _persistentData.PlayerData.Position.ToVector3();
                controller.enabled = true;
            }
            else
            {
                var spawner = GameObject.FindObjectOfType<PlayerSpawner>();
                spawner.Spawn(_player);
            }
        }
        private void SaveScene()
        {
            _persistentDataService.Save();
        }
        private void LoadScene()
        {
            SetupSceneWithObject();
        }
    }
}
