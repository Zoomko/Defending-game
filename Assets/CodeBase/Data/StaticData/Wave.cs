using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [Serializable]
    public class Wave: ICloneable
    {
        public List<EnemyParameters> Enemies;

        public int WaveTimeLengthInSeconds = 60;

        [Header("Сharacteristics")]
        public float HPScale = 1f;
        public float DamageScale = 1f;
        public float SpeedOfAttackScale = 1f;

        public object Clone()
        {
            var wave = new Wave();

            wave.WaveTimeLengthInSeconds = WaveTimeLengthInSeconds;
            wave.HPScale = HPScale;
            wave.DamageScale = DamageScale;
            wave.SpeedOfAttackScale = SpeedOfAttackScale;

            wave.Enemies = new List<EnemyParameters>();
            foreach(var enemy in Enemies)
            {
                wave.Enemies.Add(new EnemyParameters() { EnemyType = enemy.EnemyType, EmenyCount = enemy.EmenyCount });
            }
            return wave;
        }
    }
}
