using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Data.StaticData.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private PlayerStaticData _playerStaticData;
        private EnemiesStaticData _enemiesStaticData;
        private Waves _wavesStaticData;
        private BulletsStaticData _bulletsStaticData;
        private GameStaticData _gameStaticData;
        private VisualTreeAsset _hud;
        private PanelSettings _uiPanelSettings;

        public PlayerStaticData PlayerStaticData => _playerStaticData;
        public EnemiesStaticData EnemiesStaticData => _enemiesStaticData;
        public Waves WavesStaticData => _wavesStaticData;

        public GameStaticData GameStaticData => _gameStaticData;

        public BulletsStaticData BulletsStaticData => _bulletsStaticData;

        public VisualTreeAsset HUD => _hud;
        public PanelSettings UIPanelSettings => _uiPanelSettings;

        public void Load()
        {
            LoadPlayerStaticData();
            LoadEnemiesStaticData();
            LoadWavesStaticData();
            LoadBulletsStaticData();
            LoadGameStaticData();
            LoadHUD();
            LoadUIPanelSettings();
        }
        public void LoadPlayerStaticData()
        {
            _playerStaticData = Resources.Load<PlayerStaticData>(Paths.PlayerStaticDataPath);
        }
        public void LoadEnemiesStaticData()
        {
            _enemiesStaticData = Resources.Load<EnemiesStaticData>(Paths.EnemiesStaticDataPath);
        }
        public void LoadWavesStaticData()
        {
            _wavesStaticData = Resources.Load<Waves>(Paths.WavesStaticDataPath);
        }
        public void LoadBulletsStaticData()
        {
            _bulletsStaticData = Resources.Load<BulletsStaticData>(Paths.BulletStaticDataPath);
        }
        public void LoadGameStaticData()
        {
            _gameStaticData = Resources.Load<GameStaticData>(Paths.GameStaticDataPath);
        }
        public void LoadHUD()
        {
            _hud = Resources.Load<VisualTreeAsset>(Paths.HUDPath);
        }
        public void LoadUIPanelSettings()
        {
            _uiPanelSettings = Resources.Load<PanelSettings>(Paths.UIPanelSettings);
        }
    }
}
