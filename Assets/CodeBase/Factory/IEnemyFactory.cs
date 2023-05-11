using Assets.CodeBase.Data.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IEnemyFactory
    {
        GameObject Create(EnemyType enemyType);
    }
}