using System;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [Serializable]
    public class Enemy
    {
        public EnemyType Type;
        public GameObject EnemyPrefab;
    }
}
