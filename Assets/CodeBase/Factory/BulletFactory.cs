using Assets.CodeBase.App;
using Assets.CodeBase.Services;
using System.Collections.Generic;
using UnityEngine;
using Bullet = Assets.CodeBase.Bullets.Bullet;

namespace Assets.CodeBase.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly Dictionary<BulletType, Pool> _bullets;

        public BulletFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _bullets = new Dictionary<BulletType, Pool>();
        }

        public void InitializePool()
        {
            _bullets.Add(BulletType.playerBullet, new Pool(_staticDataService.BulletsStaticData.BulletsCollection[BulletType.playerBullet]));
            _bullets.Add(BulletType.enemyBullet, new Pool(_staticDataService.BulletsStaticData.BulletsCollection[BulletType.enemyBullet]));
        }

        public GameObject Create(BulletType bulletType, BulletParametes bulletParametes)
        {
            var bulletGameObject = _bullets[bulletType].Get();
            bulletGameObject.SetActive(true);
            var bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.Destroyed += OnBulletDestroy;
            bullet.Constructor(bulletParametes);
            bullet.Fly();
            return bulletGameObject;
        }

        public void OnBulletDestroy(GameObject gameObject)
        {
            var bullet = gameObject.GetComponent<Bullet>();
            bullet.Destroyed -= OnBulletDestroy;
            gameObject.SetActive(false);
            _bullets[bullet.BulletType].Put(gameObject);
        }
    }
}
