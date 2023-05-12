using Assets.CodeBase.App;
using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Enemy;
using Assets.CodeBase.Enemy.StateMachine;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerFactory _playerFactory;
        private readonly ICrystalFactory _crystalFactory;   

        private readonly Dictionary<EnemyType, Pool> _enemies;

        public EnemyFactory(IStaticDataService staticDataService, IPlayerFactory playerFactory, ICrystalFactory crystalFactory)
        {           
            _staticDataService = staticDataService;
            _playerFactory = playerFactory;
            _crystalFactory = crystalFactory;

            _enemies = new Dictionary<EnemyType, Pool>();            
        }
        public void InitializePool()
        {
            _enemies.Add(EnemyType.Creep, new Pool(_staticDataService.EnemiesStaticData.EnemiesCollection[EnemyType.Creep].EnemyPrefab));
            _enemies.Add(EnemyType.Ranger, new Pool(_staticDataService.EnemiesStaticData.EnemiesCollection[EnemyType.Ranger].EnemyPrefab));
        }

        public GameObject Create(EnemyType enemyType)
        {           
            var enemyGameObject = _enemies[enemyType].Get();
            enemyGameObject.SetActive(true);
            var enemyStateMachine = enemyGameObject.GetComponent<EnemyStateMachine>();
            var enemyHealthController = enemyGameObject.GetComponent<EnemyHealthController>();
            var enemyDieController = enemyGameObject.GetComponent<EnemyDieController>();
            enemyDieController.Died += OnEnemyDie;
            enemyHealthController.Constructor(_staticDataService.EnemiesStaticData.EnemiesCollection[enemyType].EnemyCharacteristics);
            enemyStateMachine.Contructor(_staticDataService.EnemiesStaticData.EnemiesCollection, _playerFactory.Player.transform, _crystalFactory.Crystal.transform);
            return enemyGameObject;
        }
        private void OnEnemyDie(GameObject gameObject)
        {
            var dieController = gameObject.GetComponent<EnemyDieController>();
            dieController.Died -= OnEnemyDie;
            var typeHolder = gameObject.GetComponent<EnemyTypeHolder>();            
            gameObject.SetActive(false);
            _enemies[typeHolder.EnemyType].Put(gameObject);
        }
    }
}