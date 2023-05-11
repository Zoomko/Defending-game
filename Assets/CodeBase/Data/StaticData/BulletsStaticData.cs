using Assets.CodeBase.Data.Bullets;
using Assets.CodeBase.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Data.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Bullets", fileName = "Bullets")]
    public class BulletsStaticData:ScriptableObject
    {
        [SerializeField]
        private List<Bullet> _bullets = new List<Bullet>();
        private Dictionary<BulletType, GameObject> _bulletsDictionary;

        public Dictionary<BulletType, GameObject> BulletsCollection => _bulletsDictionary;

        private void OnEnable()
        {
            _bulletsDictionary = _bullets.ToDictionary(x => x.Type, x => x.BulletPrefab);
        }
    }
}
