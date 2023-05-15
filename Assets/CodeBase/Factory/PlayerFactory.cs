using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly InputService _inputService;
        private readonly RaycastService _raycatsService;
        private readonly IStaticDataService _staticDataService;
        private readonly IBulletFactory _bulletFactory;
        private readonly UIHUDController _uiHUDController;

        private GameObject _player;

        public GameObject Player => _player;

        public PlayerFactory(InputService inputService, RaycastService raycatsService, IStaticDataService staticDataService, IBulletFactory bulletFactory, UIHUDController uiHUDController)
        {
            _inputService = inputService;
            _raycatsService = raycatsService;
            _staticDataService = staticDataService;
            _bulletFactory = bulletFactory;
            _uiHUDController = uiHUDController;
        }

        public GameObject Create()
        {
            var prefabData = _staticDataService.PlayerStaticData.PlayerPrefab;
            var playerGameObject = GameObject.Instantiate(prefabData);

            var movementController = playerGameObject.GetComponent<MovementController>();
            var fireController = playerGameObject.GetComponent<FireController>();
            var healthController = playerGameObject.GetComponent<HealthController>();
            var damagable = playerGameObject.GetComponent<IDamagable>();

            damagable.HealthChanged += _uiHUDController.OnHealthChanged;

            fireController.Constructor(_inputService, _staticDataService.PlayerStaticData, _bulletFactory);
            movementController.Contructor(_inputService, _raycatsService, _staticDataService.PlayerStaticData);
            healthController.Constructor(_staticDataService.PlayerStaticData);      

            _player = playerGameObject;
            return playerGameObject;
        }
    }
}