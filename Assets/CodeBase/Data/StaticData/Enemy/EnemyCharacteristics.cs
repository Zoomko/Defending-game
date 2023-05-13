using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData.Enemy
{
    [CreateAssetMenu(menuName = "StaticData/EnemyCharacteristics", fileName = "EnemyCharacteristics")]
    public class EnemyCharacteristics:ScriptableObject
    {
        [Range(0, 100)]
        public int HP;

        [Header("Movement")]
        public float MovementSpeed;
        public float RotationSpeed;

        [Header("Attack")]
        public float RangeOfAttack;
        public float AttackPerSecond;
        public int AttackDamage;
        public float TimeToPrepaiarForAttack;

        [Header("Bullet")]
        public float BulletRadius;      
        public float BulletLiveTime;
        public float BulletSpeed;
    }
}
