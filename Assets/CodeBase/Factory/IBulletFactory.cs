using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public interface IBulletFactory
    {
        GameObject Create(BulletType bulletType, BulletParametes bulletParametes);
    }
}