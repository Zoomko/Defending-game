using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly InputService _inputService;
        private readonly RaycastService _raycatsService;
        private readonly IStaticDataService _staticDataService;
        private readonly IBulletFactory _bulletFactory;

        private GameObject _player;

        public GameObject Player => _player;
        public PlayerFactory(InputService inputService, RaycastService raycatsService, IStaticDataService staticDataService, IBulletFactory bulletFactory)
        {
            _inputService = inputService;
            _raycatsService = raycatsService;
            _staticDataService = staticDataService;
            _bulletFactory = bulletFactory;
        }


        public GameObject Create()
        {
            var prefabData = _staticDataService.PlayerStaticData.PlayerPrefab;
            var playerGameObject = GameObject.Instantiate(prefabData);

            var movementController = playerGameObject.GetComponent<MovementController>();
            var fireController = playerGameObject.GetComponent<FireController>();
            var helathController = playerGameObject.GetComponent<HealthController>();

            fireController.Constructor(_inputService, _staticDataService.PlayerStaticData, _bulletFactory);
            movementController.Contructor(_inputService, _raycatsService, _staticDataService.PlayerStaticData);
            helathController.Constructor(_staticDataService.PlayerStaticData);

            _player = playerGameObject;
            return playerGameObject;
        }
    }
}