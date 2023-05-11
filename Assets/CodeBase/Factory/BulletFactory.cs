using Assets.CodeBase.Data.Bullets;
using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IStaticDataService _staticDataService;

        public BulletFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject Create(BulletType bulletType, BulletParametes bulletParametes)
        {
            var bulletPrefab = _staticDataService.BulletsStaticData.BulletsCollection[bulletType];
            var bulletGameObject = GameObject.Instantiate(bulletPrefab);
            var bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.Constructor(bulletParametes);
            return bulletGameObject;
        }
    }
}
