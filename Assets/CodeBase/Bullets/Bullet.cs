using Assets.CodeBase.Factory;
using Assets.CodeBase.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletType _bulletType;
        [SerializeField]
        private LayerMask _layerMask;
        private BulletParametes _bulletParametes;  
        public BulletType BulletType => _bulletType;
        public Action<GameObject> Destroyed;
        

        public void Constructor(BulletParametes bulletParametes)
        {
            _bulletParametes = bulletParametes;
            transform.localScale = Vector3.one * bulletParametes.Radius;     
        }

        public void Fly()
        {
            StartCoroutine(Flying());
        }

        private IEnumerator Flying()
        {
            float startTime = Time.time;
            float destroyTime = startTime + _bulletParametes.LiveTime;
            while (Time.time < destroyTime)
            {
                transform.position += transform.forward * Time.deltaTime * _bulletParametes.Speed;
                yield return null;
            }
            Destroyed?.Invoke(gameObject);
        }

        private void FixedUpdate()
        {
            CheckCollisions();
        }
        private void CheckCollisions()
        {
            var colliders = Physics.OverlapSphere(transform.position, _bulletParametes.Radius, _layerMask);
            if (colliders.Length >= 1)
            {                
                if (colliders.First().gameObject.TryGetComponent<IDamagable>(out var damagable))
                {
                    damagable.GetDamage(_bulletParametes.Damage);
                }
                StopAllCoroutines();
                Destroyed?.Invoke(gameObject);                
            }
        }
    }

}
