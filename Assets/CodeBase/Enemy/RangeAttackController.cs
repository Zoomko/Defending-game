using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Factory;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class RangeAttackController : MonoBehaviour, IAttackController
    {
        [SerializeField]
        private Transform _fireSpot;
        private EnemyCharacteristics _enemyCharacteristics;
        private IBulletFactory _bulletFactory;
        public void Constructor(EnemyCharacteristics enemyCharacteristics, IBulletFactory bulletFactory)
        {
            _enemyCharacteristics = enemyCharacteristics;
            _bulletFactory = bulletFactory;
        }

        public void Attack()
        {
            var parameters = new BulletParametes()
            {
                Damage = _enemyCharacteristics.AttackDamage,
                Radius = _enemyCharacteristics.BulletRadius,
                Speed = _enemyCharacteristics.BulletSpeed,
                LiveTime = _enemyCharacteristics.BulletLiveTime
            };

            var bullet = _bulletFactory.Create(BulletType.enemyBullet, parameters);
            bullet.transform.position = _fireSpot.position;
            bullet.transform.forward = _fireSpot.forward;
        }
    }
}