using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Enemies", fileName = "Enemies")]
    public class EnemiesStaticData : ScriptableObject
    {
        [SerializeField]
        private List<Enemy> _enemies = new List<Enemy>();
        private Dictionary<EnemyType, GameObject> _enemiesDictionary;

        public Dictionary<EnemyType, GameObject> EnemiesCollection => _enemiesDictionary;

        private void OnEnable()
        {
            _enemiesDictionary = _enemies.ToDictionary(x => x.Type, x => x.EnemyPrefab);
        }
    }
}
