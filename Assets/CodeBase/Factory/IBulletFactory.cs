using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IBulletFactory
    {
        void InitializePool();
        GameObject Create(BulletType bulletType, BulletParametes bulletParametes);
    }
}