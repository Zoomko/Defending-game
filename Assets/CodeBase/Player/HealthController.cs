using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.CodeBase.Player
{
    [RequireComponent(typeof(DieController))]
    public class HealthController : MonoBehaviour, IDamagable
    {
        private PlayerStaticData _playerStaticData;
        private DieController _dieController;
        private int _maxHealth;
        private int _health;

        public event Action<int, int, int> HealthChanged;

        public void Constructor(PlayerStaticData playerStaticData)
        {
            _playerStaticData = playerStaticData;
            _maxHealth = playerStaticData.HP;
            _health = _maxHealth;
            HealthChanged?.Invoke(_health, _maxHealth, 0);
        }

        private void Awake()
        {
            _dieController = GetComponent<DieController>();
        }

        public void GetDamage(int value)
        {
            var result = Mathf.Max(0, _health - value);
            if(result == 0)
            {
                _dieController.Die();
            }
            HealthChanged?.Invoke(result, _maxHealth, value);
            _health = result;
        }

    }
}
