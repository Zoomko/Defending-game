using Assets.CodeBase.Factory;
using Assets.CodeBase.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletType _bulletType;
        private BulletParametes _bulletParametes;
        public BulletType BulletType => _bulletType;

        public void Constructor(BulletParametes bulletParametes)
        {
            _bulletParametes = bulletParametes;
        }

        private void Start()
        {
            StartCoroutine(Fly());
        }

        private IEnumerator Fly()
        {
            float startTime = Time.time;
            float destroyTime = startTime + _bulletParametes.LiveTime;
            while (Time.time < destroyTime)
            {
                transform.position += transform.forward * Time.deltaTime * _bulletParametes.Speed;
                yield return null;
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.GetDamage(_bulletParametes.Damage);
            }
        }
    }
   
}
