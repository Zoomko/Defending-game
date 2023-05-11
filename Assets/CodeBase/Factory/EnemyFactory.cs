using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        public GameObject Create(EnemyType enemyType)
        {
            var enemyPrefabData = _staticDataService.EnemiesStaticData.EnemiesCollection[enemyType];
            var enemyGameObject = GameObject.Instantiate(enemyPrefabData);
            return enemyGameObject;
        }
    }
}