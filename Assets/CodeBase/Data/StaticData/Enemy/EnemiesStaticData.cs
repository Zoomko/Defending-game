using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData.Enemy
{
    [CreateAssetMenu(menuName = "StaticData/Enemies", fileName = "Enemies")]
    public class EnemiesStaticData : ScriptableObject
    {
        [SerializeField]
        private List<EnemyInfo> _enemies = new List<EnemyInfo>();
        private Dictionary<EnemyType, EnemyInfo> _enemiesDictionary;

        public Dictionary<EnemyType, EnemyInfo> EnemiesCollection => _enemiesDictionary;

        private void OnEnable()
        {
            _enemiesDictionary = _enemies.ToDictionary(x => x.Type);
        }
    }
}
