using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Player;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class MeleeAttackController : MonoBehaviour, IAttackController
    {
        private EnemyCharacteristics _enemyCharacteristics;
        private LayerMask _layerMask;
        private Collider[] _colliders;
        public void Constructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;
        }
        private void Start()
        {
            _layerMask = ( 1 << LayerMask.NameToLayer("Ally") );
            _colliders = new Collider[1];
        }

        public void Attack()
        {
            var spherePosition = transform.position + transform.forward * (0.5f * _enemyCharacteristics.RangeOfAttack);
            var sphereRadius = _enemyCharacteristics.RangeOfAttack / 2f;
            int hits = RotaryHeart.Lib.PhysicsExtension.Physics.OverlapSphereNonAlloc(spherePosition, sphereRadius, _colliders, _layerMask, RotaryHeart.Lib.PhysicsExtension.PreviewCondition.Both,1f, Color.green, Color.red);
            if(hits > 0 && _colliders.First().gameObject.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.GetDamage(_enemyCharacteristics.AttackDamage);
            }
        }
    }
}