using Assets.CodeBase.Factory;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class FireController : MonoBehaviour
    {
        [SerializeField]
        private Transform _fireSpot;
        private InputService _inputService;
        private PlayerStaticData _playerStaticData;
        private IBulletFactory _bulletFactory;
        public void Constructor(InputService inputService, PlayerStaticData playerStaticData, IBulletFactory bulletFactory)
        {
            _inputService = inputService;
            _playerStaticData = playerStaticData;
            _bulletFactory = bulletFactory;
            _inputService.Attacked += OnAttackButtonPressed;
        }
        private void OnDestroy()
        {
            _inputService.Attacked -= OnAttackButtonPressed;
        }
        private void OnAttackButtonPressed()
        {
            StartCoroutine(Fire());
        }
        private IEnumerator Fire()
        {
            var bulletParameters = new BulletParametes()
            {
                Damage = _playerStaticData.BulletDamage,
                LiveTime = _playerStaticData.BulletLiveTime,
                Speed = _playerStaticData.BulletSpeed
            };
            while (_inputService.IsAttacking)
            {  
                var bullet = _bulletFactory.Create(BulletType.playerBullet, bulletParameters);
                bullet.transform.position = _fireSpot.position;
                bullet.transform.forward = _fireSpot.forward;
                yield return new WaitForSeconds(1f / _playerStaticData.AttackSpeed);
            }
        }

    }
}
