using Assets.CodeBase.Data.StaticData.Enemy;
using Assets.CodeBase.Player;
using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyDieController))]
    public class EnemyHealthController : MonoBehaviour, IDamagable
    {
        private EnemyCharacteristics _enemyCharacteristics;
        private EnemyDieController _dieController;
        private int _maxHealth;
        private int _health;

        public event Action<int, int, int> HealthChanged;

        public void Constructor(EnemyCharacteristics enemyCharacteristics)
        {
            _enemyCharacteristics = enemyCharacteristics;
            _maxHealth = enemyCharacteristics.HP;
            _health = _maxHealth;
        }

        private void Awake()
        {
            _dieController = GetComponent<EnemyDieController>();
        }

        public void GetDamage(int value)
        {
            var result = Mathf.Max(0, _health - value);
            if (result == 0)
            {
                _dieController.Die();
            }
            HealthChanged?.Invoke(result, _maxHealth, value);
            _health = result;
        }
    }
}