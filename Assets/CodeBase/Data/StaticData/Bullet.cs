using Assets.CodeBase.Factory;
using System;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [Serializable]
    public class Bullet
    {
        public BulletType Type;
        public GameObject BulletPrefab;
    }
}
