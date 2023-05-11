using Assets.CodeBase.App.Services;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.App.StateMachine
{
    public class WaveController
    {
        private readonly IStaticDataService _staticDataService;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly IEnemyFactory _enemyFactory;
        private EnemySpawner[] _enemySpawners;

        private int _currentWave = 0;
        public WaveController(IStaticDataService staticDataService, CoroutineRunner coroutineRunner, IEnemyFactory enemyFactory)
        {   
            _staticDataService = staticDataService;
            _coroutineRunner = coroutineRunner;
            _enemyFactory = enemyFactory;
        }
        public void StartWave()
        {
            if(_enemySpawners == null)
                _enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();
            var wave = _staticDataService.WavesStaticData.EnemyWaves[_currentWave].Clone() as Wave;
            _coroutineRunner.StartCoroutine(WaveInProcess(wave));
        }
        
        private IEnumerator WaveInProcess(Wave wave)
        {
            float waveTime = wave.WaveTimeLengthInSeconds;
            float countOfEnemies = wave.Enemies.Sum(x => x.EmenyCount);
            float timeForOneBatch = waveTime / (countOfEnemies / _enemySpawners.Count());

            for(int i = 0; i < wave.Enemies.Count; i++)
            {
                while (wave.Enemies[i].EmenyCount > 0)
                {
                    for(int j = 0; j < _enemySpawners.Count(); j++)
                    {
                        var enemy = _enemyFactory.Create(wave.Enemies[i].EnemyType);
                        _enemySpawners[j].Spawn(enemy);
                        wave.Enemies[i].EmenyCount--;
                        if (wave.Enemies[i].EmenyCount <= 0)
                            break;
                    }
                    yield return new WaitForSeconds(timeForOneBatch);
                }
            }

            PrepairToNextWave();
        }
        private void PrepairToNextWave()
        {
            _currentWave++;
            _coroutineRunner.StartCoroutine(PrepairingToNextWave());
        }
        private IEnumerator PrepairingToNextWave()
        {
            yield return new WaitForSeconds(10f);
            StartWave();
        }
    }
}
