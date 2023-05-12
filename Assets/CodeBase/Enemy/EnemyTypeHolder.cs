using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyTypeHolder : MonoBehaviour
    {
        [SerializeField]
        private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;
    }
}
