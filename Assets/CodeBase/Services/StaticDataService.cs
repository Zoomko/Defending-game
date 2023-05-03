using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class StaticDataService : IStaticDataService
    {
        private PlayerStaticData _playerStaticData;
        public PlayerStaticData PlayerStaticData => _playerStaticData;
        public StaticDataService()
        {
            Load();
        }
        public void Load()
        {
            LoadPlayerStaticData();
        }
        public void LoadPlayerStaticData()
        {
            _playerStaticData = Resources.Load<PlayerStaticData>(Paths.PlayerStaticDataPath);
        }
    }
}
