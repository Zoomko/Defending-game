using Assets.CodeBase.Data.StaticData.Enemy;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IEnemyFactory
    {
        void InitializePool();
        GameObject Create(EnemyType enemyType);
    }
}